using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

namespace PortableDnsProxy
{
    public class DnsProxyServer
    {
        internal Working StatusWindow { get; set; }
        internal Utils.DbSettings Settings { get; set; }
        internal Dictionary<string, X509Certificate> Certificates { get; set; }
        internal DateTime LastInternetDownNotification = DateTime.MinValue;
        private TcpListener Listener { get; set; }

        private bool StopAccepting { get; set; }
        internal bool DisplayedProxyServerTlsImpotence { get; set; }

        public ManualResetEvent allDone = new ManualResetEvent(false);

        public DnsProxyServer(Working statusWindow, Utils.DbSettings settings)
        {
            StatusWindow = statusWindow;
            Settings = settings;
            Certificates = Utils.GetCachedCertificates();

            StopAccepting = false;
        }

        public void Start()
        {
            try
            {
                Listener = new TcpListener(IPAddress.Loopback, Settings.Port);
                Listener.Start(100);
            }
            catch (Exception e)
            {
                Utils.ShowError("Error starting the DNS Proxy: " + e.Message);
                return;
            }

            while (!StopAccepting)
            {
                try
                {
                    TcpClient client = Listener.AcceptTcpClient();

                    DnsProxyClientHandler clientHandler = new DnsProxyClientHandler(this, client);

                    new Thread(new ThreadStart(clientHandler.HandleConnection)).Start();
                }
                catch(Exception)
                {
                    // bad request
                }
            }
        }
        
        public void Stop()
        {
            StopAccepting = true;
            Listener.Stop();
        }
    }
}
