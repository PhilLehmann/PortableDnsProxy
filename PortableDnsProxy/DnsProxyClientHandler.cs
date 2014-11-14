using CERTENROLLLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

namespace PortableDnsProxy
{
    class DnsProxyClientHandler
    {
        DnsProxyServer Server { get; set; }
        TcpClient ClientConnection { get; set; }
        ulong RequestId { get; set; }

        public DnsProxyClientHandler(DnsProxyServer server, TcpClient client)
        {
            Server = server;
            ClientConnection = client;
        }

        public void HandleConnection()
        {
            Debug.WriteLine(RequestId + " started.");

            TcpClient serverConnection = null;
            NetworkStream clientStream = null;
            NetworkStream serverStream = null;

            bool statsRedirected = false;

            try
            {
                // Establish the connection
                clientStream = ClientConnection.GetStream();
                clientStream.ReadTimeout = 5000;

                Utils.HttpRequestHeaders lastHttpRequestHeaders = null;

                do
                {
                    // Read complete request HTTP headers
                    Utils.HttpRequestHeaders httpRequestHeaders = Utils.ReadRequestHttpHeaders(clientStream, RequestId);

                    RequestId = Server.StatusWindow.AddReceivedRequestToStatistic();
                    Debug.WriteLine(RequestId + " " + httpRequestHeaders.Verb + " " + httpRequestHeaders.Hostname + ":" + httpRequestHeaders.Port);

                    if(httpRequestHeaders.Hostname.ToLower().Equals("portablednsproxy"))
                    {
                        Utils.WriteStringToStream("Thanks for using Portable DNS Proxy :-)", clientStream);
                        return;
                    }

                    if (lastHttpRequestHeaders == null ||
                        !httpRequestHeaders.Hostname.Equals(lastHttpRequestHeaders.Hostname) ||
                        httpRequestHeaders.Port != lastHttpRequestHeaders.Port)
                    {
                        // Replace hostname with configured values if matching
                        statsRedirected = false;
                        foreach (Utils.DbHost host in Server.Settings.Hosts)
                        {
                            if (httpRequestHeaders.Hostname.ToLower().Equals(host.OriginalName.ToLower()))
                            {
                                if (host.RedirectedNameOrIp != null)
                                {
                                    httpRequestHeaders.Hostname = host.RedirectedNameOrIp;
                                }

                                if (host.RewrittenHostHeader != null)
                                {
                                    Utils.RewriteHostnameInHeaders(httpRequestHeaders, host.OriginalName, host.RewrittenHostHeader);
                                }

                                statsRedirected = true;
                                break;
                            }
                        }

                        // Proxy the request to the target host
                        serverConnection = GetSettingsConformantServerTcpClient(Server, httpRequestHeaders.Hostname, httpRequestHeaders.Port);
                        serverStream = serverConnection.GetStream();

                        lastHttpRequestHeaders = httpRequestHeaders;
                    }

                    if (!HandleRequest(httpRequestHeaders, statsRedirected, clientStream, serverStream))
                    {
                        break;
                    }
                }
                while (true);

                // Done. Next, please! Well, we are doing async / keep alive, so it may have already been started.
            }
            catch (Exception e)
            {
                // done
                Debug.WriteLine(RequestId + " finished with exception.");

                if(clientStream != null && clientStream.CanWrite)
                {
                    try
                    {
                        Utils.WriteStringToStream("An error happened while working on your request: " + e.Message, clientStream);
                    }
                    catch(Exception)
                    { }
                }
            }
            finally
            {
                if (ClientConnection != null && ClientConnection.Connected)
                {
                    ClientConnection.Close();
                }

                if (serverConnection != null && serverConnection.Connected)
                {
                    serverConnection.Close();
                }

                if (serverStream != null)
                {
                    serverStream.Close();
                    serverStream.Dispose();
                }

                if (clientStream != null)
                {
                    clientStream.Close();
                    clientStream.Dispose();
                }
            }
        }

        private bool HandleRequest(Utils.HttpRequestHeaders httpRequestHeaders, bool statsRedirected, Stream clientStream, Stream serverStream)
        {
            ulong statsSent = 0;
            ulong statsReceived = 0;

            bool loadContent = true;

            switch (httpRequestHeaders.Verb)
            {
                case "GET":
                case "POST":
                case "PUT":
                case "DELETE":
                case "TRACE":
                case "OPTIONS":
                    // You may pass!
                    break;

                case "HEAD":
                    // Do not load content!
                    loadContent = false;
                    break;

                case "CONNECT":
                    // TLS tunnel request

                    Debug.WriteLine(RequestId + " has CONNECT verb, initiating TLS tunnel.");
                    Server.StatusWindow.AddServedRequestToStatistic(statsRedirected, statsSent, 0, true);
                    HandleTlsUpgrade(RequestId, httpRequestHeaders, statsRedirected, clientStream, serverStream);
                    return false;
            }

            // First, the HTTP Headers
            statsSent += Utils.WriteStringToStream(httpRequestHeaders.Headers, serverStream);

            // Now, the post data
            if (httpRequestHeaders.ContentLength > 0)
            {
                Utils.ProxyStream(clientStream, serverStream, httpRequestHeaders.ContentLength);
                statsSent += httpRequestHeaders.ContentLength;
            }

            Debug.WriteLine(RequestId + " bytes sent: " + statsSent);

            // Read response HTTP headers first and determine content length
            Utils.HttpResponseHeaders httpResponseHeaders = Utils.ReadResponseHttpHeaders(serverStream, RequestId);

            // Return the headers first
            statsReceived += Utils.WriteStringToStream(httpResponseHeaders.Headers, clientStream);

            // For verb HEAD and response code 304, we don't get content :-/
            if (loadContent && !httpResponseHeaders.StatusCode.Equals("304"))
            {
                if(httpResponseHeaders.IsChunked)
                {
                    statsReceived += Utils.ProxyChunkStream(serverStream, clientStream);
                }
                else if (httpResponseHeaders.ContentLength > 0)
                {
                    // Now, the content
                    Utils.ProxyStream(serverStream, clientStream, httpResponseHeaders.ContentLength);
                    statsReceived += httpResponseHeaders.ContentLength;
                }
            }

            Debug.WriteLine(RequestId + " bytes received: " + statsReceived);

            Server.StatusWindow.AddServedRequestToStatistic(statsRedirected, statsSent, statsReceived);
            Debug.WriteLine(RequestId + " request finished.");

            return httpResponseHeaders.KeepAlive;
        }

        private void HandleTlsUpgrade(ulong requestId, Utils.HttpRequestHeaders httpRequestHeaders, bool statsRedirected, Stream clientStream, Stream serverStream)
        {
            SslStream serverTlsStream = null;
            SslStream clientTlsStream = null;

            try
            {
                serverTlsStream = new SslStream(serverStream, false, new RemoteCertificateValidationCallback(ValidateServerCertificate));

                // Say hello to server
                string strSSLResponse = "";
                byte[] bytSSLResponse;
                try
                {
                    serverTlsStream.AuthenticateAsClient(httpRequestHeaders.Hostname);
                }
                catch (Exception)
                {
                    //bad certificate 
                    strSSLResponse = "HTTP/1.0 401 Bad Certificate\r\n\r\n";
                    bytSSLResponse = Encoding.UTF8.GetBytes(strSSLResponse);
                    clientStream.Write(bytSSLResponse, 0, bytSSLResponse.Length);
                    return;
                }

                // Give client "ok"
                Utils.WriteStringToStream("HTTP/1.0 200 Connection established\r\n\r\n", clientStream);
            
                // Say hello to client; make sure the socket is in blocking mode else this will fail with WOULDBLOCK
                clientTlsStream = new SslStream(clientStream, false, new RemoteCertificateValidationCallback(ValidateServerCertificate));
                clientTlsStream.ReadTimeout = 15000;

                // Remote certificate is not working
                // X509Certificate certificate = serverTlsStream.RemoteCertificate;

                // Create self signet certificate and cache for next request
                X509Certificate certificate;
                if (Server.Certificates.ContainsKey(httpRequestHeaders.Hostname))
                {
                    certificate = Server.Certificates[httpRequestHeaders.Hostname];
                }
                else
                {
                    certificate = CreateSelfSignedCertificate(httpRequestHeaders.Hostname);

                    Utils.CacheCertificate(httpRequestHeaders.Hostname, certificate);
                    Server.Certificates.Add(httpRequestHeaders.Hostname, certificate);
                    Server.StatusWindow.AddNewTlsCertToStatistic();
                    Server.StatusWindow.SetTlsCertBlocked(httpRequestHeaders.Hostname, true);
                }

                clientTlsStream.AuthenticateAsServer(certificate); 

                while (true)
                {
                    Utils.HttpRequestHeaders newHttpRequestHeaders;
                    try
                    {
                        // Read complete request HTTP headers
                        newHttpRequestHeaders = Utils.ReadRequestHttpHeaders(clientTlsStream);
                    }
                    catch(IOException e)
                    {
                        if(e.InnerException != null && 
                           e.InnerException.GetType().Equals(typeof(SocketException)) &&
                           ((SocketException)e.InnerException).SocketErrorCode == SocketError.ConnectionAborted)
                        {
                            Server.StatusWindow.SetTlsCertBlocked(httpRequestHeaders.Hostname, true);
                        }

                        throw e;
                    }

                    Server.StatusWindow.SetTlsCertBlocked(newHttpRequestHeaders.Hostname, false);

                    RequestId = Server.StatusWindow.AddReceivedRequestToStatistic();

                    clientTlsStream.ReadTimeout = 5000;

                    HandleRequest(newHttpRequestHeaders, statsRedirected, clientTlsStream, serverTlsStream);
                }
            }
            catch (Exception)
            {
                // Premature end (bad) or timeout due to no new requests (ok)
            }
            finally
            {
                Server.StatusWindow.AddClosedTLSTunnelToStatistic();

                if (serverTlsStream != null)
                {
                    serverTlsStream.Close();
                }

                if (clientTlsStream != null)
                {
                    clientTlsStream.Close();
                }
            }
        }

        public static TcpClient GetSettingsConformantServerTcpClient(DnsProxyServer server, string serverHost, int serverPort)
        {
            if (server.Settings.ProxyType == Utils.DbProxyType.None)
            {
                return new TcpClient(serverHost, serverPort);
            }
            else if (server.Settings.ProxyType == Utils.DbProxyType.SystemDefault)
            {
                Uri serverHostUri = new Uri(serverHost + ":" + serverPort);
                if(server.SystemDefaultProxy.IsBypassed(serverHostUri))
                {
                    return new TcpClient(serverHost, serverPort);
                }
                else
                {
                    Uri proxyUri = server.SystemDefaultProxy.GetProxy(serverHostUri);

                    return new Starksoft.Net.Proxy.ProxyClientFactory().
                               CreateProxyClient(proxyUri.ToProxyType(), proxyUri.Host, proxyUri.Port).
                               CreateConnection(serverHost, serverPort);
                }
            }
            else
            {
                return new Starksoft.Net.Proxy.ProxyClientFactory().
                           CreateProxyClient(server.Settings.ProxyType.ToProxyType(), server.Settings.ProxyHost, server.Settings.ProxyPort).
                           CreateConnection(serverHost, serverPort);
            }
        }

        private bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        public static X509Certificate2 CreateSelfSignedCertificate(string hostname)
        {
            var distinguishedName = new CX500DistinguishedName();
            distinguishedName.Encode("CN=" + hostname + ";O=Issued by PortableDnsProxy for TLS browsing.");

            // Create private key
            CX509PrivateKey privateKey = new CX509PrivateKey();
            privateKey.ProviderName = "Microsoft Base Cryptographic Provider v1.0";
            privateKey.Length = 2048;
            privateKey.ExportPolicy = X509PrivateKeyExportFlags.XCN_NCRYPT_ALLOW_PLAINTEXT_EXPORT_FLAG;
            privateKey.Create();

            // Create hashing algorithm configuration
            var hashAlgorithm = new CObjectId();
            hashAlgorithm.InitializeFromAlgorithmName(ObjectIdGroupId.XCN_CRYPT_HASH_ALG_OID_GROUP_ID,
                                                      ObjectIdPublicKeyFlags.XCN_CRYPT_OID_INFO_PUBKEY_ANY,
                                                      AlgorithmFlags.AlgorithmFlagsNone, 
                                                      "SHA512");

            // Create self signing request
            var certificateRequest = new CX509CertificateRequestCertificate();
            certificateRequest.InitializeFromPrivateKey(X509CertificateEnrollmentContext.ContextUser, privateKey, "");
            certificateRequest.Subject = distinguishedName;
            certificateRequest.Issuer = distinguishedName;
            certificateRequest.HashAlgorithm = hashAlgorithm;
            certificateRequest.NotBefore = DateTime.Now;
            certificateRequest.NotAfter = DateTime.Now.AddYears(10);
            certificateRequest.Encode();

            // Sign the certificate
            var enrollment = new CX509Enrollment();
            enrollment.InitializeFromRequest(certificateRequest);
            enrollment.CertificateFriendlyName = hostname;

            string base64CertificateRequest = enrollment.CreateRequest();

            enrollment.InstallResponse(InstallResponseRestrictionFlags.AllowUntrustedCertificate,
                                       base64CertificateRequest, 
                                       EncodingType.XCN_CRYPT_STRING_BASE64, 
                                       "");

            var base64PfxCertificate = enrollment.CreatePFX("", PFXExportOptions.PFXExportChainWithRoot);

            return new X509Certificate2(Convert.FromBase64String(base64PfxCertificate), "", X509KeyStorageFlags.Exportable);
        }
    }
}
