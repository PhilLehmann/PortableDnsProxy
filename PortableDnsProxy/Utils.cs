using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;

namespace PortableDnsProxy
{
    public class Utils
    {
        #region Settings

        public static string CertificateStore
        {
            get
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                       Path.DirectorySeparatorChar +
                       "PhilsIndustries" +
                       Path.DirectorySeparatorChar +
                       "PortableDnsProxy" +
                       Path.DirectorySeparatorChar +
                       "CertificateStore";
            }
        }

        public class DbSettings
        {
            public Starksoft.Net.Proxy.ProxyType ProxyType { get; internal set; }
            public string ProxyHost { get; internal set; }
            public int ProxyPort { get; internal set; }

            public int Port { get; internal set; }
            public List<DbHost> Hosts { get; internal set; }
        }

        public class DbHost
        {
            public DbHost(string name, string ip)
            {
                this.OriginalName = name;
                this.TargetNameOrIp = ip;
            }

            public string OriginalName { get; internal set; }
            public string TargetNameOrIp { get; internal set; }
        }
        
        public static DbSettings ReadSettings()
        {
            RegistryKey settingKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\PhilsIndustries\\PortableDnsProxy");

            if(settingKey == null)
            {
                return null;
            }

            RegistryKey hostsKey = settingKey.OpenSubKey("Hosts");

            if (hostsKey == null)
            {
                return null;
            }

            DbSettings settings = new DbSettings();

            List<string> valueNames = new List<string>(settingKey.GetValueNames());

            string proxyType = (string)settingKey.GetValue("proxy_type");

            if(proxyType != null)
            {
                string proxyHost = settingKey.GetValue("proxy_host").ToString();
                string proxyPortString = settingKey.GetValue("proxy_port").ToString();

                if(proxyHost != null && proxyPortString != null && !proxyHost.Equals("") && !proxyPortString.Equals(""))
                {
                    int proxyPort;
                    if (!int.TryParse(proxyPortString, out proxyPort) || proxyPort < 1 || proxyPort > 65535)
                    {
                        Utils.ShowError("Please enter a valid port number [1 - 65535] for your HTTP proxy into the HTTP proxy textbox of the configuration screen and save that configuration.");
                        return null;
                    }

                    settings.ProxyHost = proxyHost;
                    settings.ProxyPort = proxyPort;
                    settings.ProxyType = (Starksoft.Net.Proxy.ProxyType) Enum.Parse(typeof(Starksoft.Net.Proxy.ProxyType), proxyType, true);
                }
            }

            int port;
            if (!int.TryParse(settingKey.GetValue("port").ToString(), out port) || port < 1 || port > 65535)
            {
                Utils.ShowError("Please enter a valid port number [1 - 65535] into the port textbox of the configuration screen and save that configuration.");
                return null;
            }

            settings.Port = port;

            settings.Hosts = new List<DbHost>();

            foreach (string name in hostsKey.GetValueNames())
            {
                settings.Hosts.Add(new DbHost(name, hostsKey.GetValue(name).ToString()));
            }

            return settings;
        }

        public static bool CertificatesExist()
        {
            if (!Directory.Exists(CertificateStore))
            {
                Directory.CreateDirectory(CertificateStore);
            }

            if (new List<string>(Directory.EnumerateFiles(CertificateStore)).Count > 0)
            {
                return true;
            }

            return false;
        }

        public static void ClearCertificates()
        {
            if (!Directory.Exists(CertificateStore))
            {
                return;
            }

            foreach(string file in Directory.EnumerateFiles(CertificateStore))
            {
                File.Delete(file);
            }
        }

        public static void CacheCertificate(string hostname, X509Certificate certificate)
        {
            if (!Directory.Exists(CertificateStore))
            {
                Directory.CreateDirectory(CertificateStore);
            }

            File.WriteAllBytes(CertificateStore + Path.DirectorySeparatorChar + hostname, certificate.Export(X509ContentType.Cert));
        }

        public static Dictionary<string, X509Certificate> GetCachedCertificates()
        {
            if (!Directory.Exists(CertificateStore))
            {
                Directory.CreateDirectory(CertificateStore);
            }

            Dictionary<string, X509Certificate> cachedCertificates = new Dictionary<string, X509Certificate>();
            
            bool error = false;
            foreach (string file in Directory.EnumerateFiles(CertificateStore))
            {
                try
                {
                    cachedCertificates.Add(Path.GetFileName(file), new X509Certificate(File.ReadAllBytes(file)));
                }
                catch(Exception)
                {
                    error = true;
                }
            }

            if(error)
            {
                ShowError("The cached certificate for at least one host could not be read from the cache, so they were dropped.");
            }

            return cachedCertificates;
        }

        public static TcpClient GetSettingsConformantServerTcpClient(DnsProxyServer server, string serverHost, int serverPort)
        {
            if(server.Settings.ProxyType == Starksoft.Net.Proxy.ProxyType.None)
            {
                return new TcpClient(serverHost, serverPort);
            }
            else
            {
                return new Starksoft.Net.Proxy.ProxyClientFactory().
                           CreateProxyClient(server.Settings.ProxyType, server.Settings.ProxyHost, server.Settings.ProxyPort).
                           CreateConnection(serverHost, serverPort);
            }
        }

        #endregion

        # region Stream Helplings

        public static string ReadLineFromStream(Stream stream)
        {
            StringBuilder stringBuilder = new StringBuilder();
            char character;

            while ((character = (char)stream.ReadByte()) >= 0)
            {
                stringBuilder.Append(character);

                // includes both \r and \n within the string
                if (character == '\n')
                {
                    break;
                }
            }

            return stringBuilder.ToString();
        }

        public static ulong WriteStringToStream(string line, Stream stream)
        {
            byte[] lineBuffer = Encoding.UTF8.GetBytes(line);
            stream.Write(lineBuffer, 0, lineBuffer.Length);
            return Convert.ToUInt64(lineBuffer.Length);
        }

        #endregion

        #region HTTP Protocol

        public class HttpRequestHeaders
        {
            public string Headers { get; set; }

            public string Verb { get; set; }
            public string Hostname { get; set; }
            public int Port { get; set; }
            public ulong ContentLength { get; set; }
        }

        public static HttpRequestHeaders ReadRequestHttpHeaders(Stream clientStream, ulong? connectionId = null)
        {
            HttpRequestHeaders response = new HttpRequestHeaders();
            StringBuilder httpRequestHeaders = new StringBuilder();

            if (connectionId.HasValue)
            {
                Debug.WriteLine(connectionId + " client header reading started.");
            }

            int line = 0;
            while (true)
            {
                string httpHeader = Utils.ReadLineFromStream(clientStream);

                if (line++ == 0)
                {
                    string[] firstLineTokens = httpHeader.Split(' ');
                    response.Verb = firstLineTokens[0].ToUpper();

                    if (connectionId.HasValue)
                    {
                        Debug.WriteLine(connectionId + " first client header line:" + httpHeader);
                    }
                }
                else
                {
                    string normalizedHttpHeader = httpHeader.ToLower();
                    if (normalizedHttpHeader.StartsWith("host"))
                    {
                        response.Hostname = httpHeader.Substring(httpHeader.IndexOf(':') + 1).Trim();

                        if (response.Hostname.Contains(":"))
                        {
                            int colonPosition = response.Hostname.IndexOf(':');
                            response.Port = int.Parse(response.Hostname.Substring(colonPosition + 1));
                            response.Hostname = response.Hostname.Substring(0, colonPosition);
                        }
                        else
                        {
                            response.Port = 80;
                        }
                    }
                    else if (normalizedHttpHeader.StartsWith("content-length"))
                    {
                        response.ContentLength = ulong.Parse(httpHeader.Substring("content-length:".Length));
                    }
                }

                httpRequestHeaders.Append(httpHeader);
                if (httpHeader.Equals("\r\n"))
                {
                    break;
                }
            }

            response.Headers = httpRequestHeaders.ToString();
            return response;
        }

        public class HttpResponseHeaders
        {
            public string Headers { get; set; }

            public ulong ContentLength { get; set; }
            public bool KeepAlive { get; set; }
            public string HttpVersion { get; set; }
            public string StatusCode { get; set; }
            public bool IsChunked { get; set; }
        }

        public static HttpResponseHeaders ReadResponseHttpHeaders(Stream clientStream, ulong? connectionId = null)
        {
            HttpResponseHeaders response = new HttpResponseHeaders();
            StringBuilder httpRequestHeaders = new StringBuilder();

            if (connectionId.HasValue)
            {
                Debug.WriteLine(connectionId + " server header reading started.");
            }

            int line = 0;
            while (true)
            {
                string httpHeader = Utils.ReadLineFromStream(clientStream);

                if (line++ == 0)
                {
                    string[] firstLineTokens = httpHeader.Split(' ');
                    response.HttpVersion = firstLineTokens[0];
                    response.StatusCode = firstLineTokens[1];

                    if (connectionId.HasValue)
                    {
                        Debug.WriteLine(connectionId + " first server header line:" + httpHeader);
                    }
                }
                else
                {
                    string normalizedHttpHeader = httpHeader.ToLower();
                    if (normalizedHttpHeader.StartsWith("content-length"))
                    {
                        response.ContentLength = ulong.Parse(httpHeader.Substring("content-length:".Length));
                    }
                    else if (normalizedHttpHeader.Contains("connection: keep-alive"))
                    {
                        response.KeepAlive = true;
                    }
                    else if (normalizedHttpHeader.Contains("transfer-encoding: chunked"))
                    {
                        response.IsChunked = true;
                    }
                }

                httpRequestHeaders.Append(httpHeader);
                if (httpHeader.Equals("\r\n"))
                {
                    break;
                }
            }

            if (response.HttpVersion.Equals("HTTP/1.1"))
            {
                response.KeepAlive = true;
            }

            response.Headers = httpRequestHeaders.ToString();
            return response;
        }

        static byte[] proxyStreamBuffer = new byte[32768];
        public static void ProxyStream(Stream sourceStream, Stream targetStream, ulong noOfBytesToRead)
        {
            int totalBytesRead = 0;
            int bytesRead = 0;

            while (noOfBytesToRead > 0)
            {
                int noOfBytes = 0;

                if (noOfBytesToRead > int.MaxValue)
                {
                    noOfBytes = int.MaxValue;
                    noOfBytesToRead -= int.MaxValue;
                }
                else
                {
                    noOfBytes = Convert.ToInt32(noOfBytesToRead);
                    noOfBytesToRead -= Convert.ToUInt64(noOfBytes);
                }

                while (totalBytesRead < noOfBytes)
                {
                    int readNow = proxyStreamBuffer.Length;

                    if(noOfBytes < readNow)
                    {
                        readNow = noOfBytes;
                    }

                    bytesRead = sourceStream.Read(proxyStreamBuffer, 0, readNow);
                    targetStream.Write(proxyStreamBuffer, 0, bytesRead);
                    totalBytesRead += bytesRead;
                }
            }

            // TODO: update stats for large files and partial (e.g. cancelled) downloads
        }

        // http://en.wikipedia.org/wiki/Chunked_transfer_encoding
        public static ulong ProxyChunkStream(Stream sourceStream, Stream targetStream)
        {
            ulong totalBytesRead = 0;

            while(true)
            {
                string chunkLengthCandidate = Utils.ReadLineFromStream(sourceStream);
                ulong chunkLength = Convert.ToUInt64(chunkLengthCandidate.Trim(), 16);

                Utils.WriteStringToStream(chunkLengthCandidate, targetStream);
                totalBytesRead += Convert.ToUInt64(chunkLengthCandidate.Length);

                if (chunkLength == 0)
                {
                    // Transfer last empty line
                    Utils.WriteStringToStream(Utils.ReadLineFromStream(sourceStream), targetStream);
                    totalBytesRead += 2;
                    break;
                }

                ProxyStream(sourceStream, targetStream, chunkLength + 2);
                totalBytesRead += chunkLength + 2;
            }

            return totalBytesRead;
        }

        #endregion

        #region General Utils

        public static void ShowError(string message, string title = "Oops!")
        {
            MessageBox.Show(message,
                            title,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error,
                            MessageBoxDefaultButton.Button1);
        }

        public static void ShowInfo(string message, string title = "For your information")
        {
            MessageBox.Show(message,
                            title,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1);
        }
        
        public static bool IsInternetAvailable()
        {
            try
            {
                if (NetworkInterface.GetIsNetworkAvailable())
                {
                    byte[] pingBuffer = new byte[32];
                    PingReply pingReply = new Ping().Send("google.com", 1000, pingBuffer, new PingOptions());

                    if (pingReply.Status == IPStatus.Success)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch(Exception)
            {
                return false;
            }
        }
        
        #endregion
    }
}
