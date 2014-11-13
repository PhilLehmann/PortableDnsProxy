using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

namespace PortableDnsProxy
{
    public partial class Working : Form
    {
        private DnsProxyServer Proxy { get; set; }

        ulong totalRequestsReceived = 0;
        ulong totalRequestsServed = 0;
        ulong totalRequestsRedirected = 0;
        ulong totalBytesSent = 0;
        ulong totalBytesReceived = 0;

        ulong totalTlsTunnelOpen = 0;
        int totalTlsCertsInStore = 0;
        int totalTlsCertsNew = 0;
        List<string> blockedTlsCerts;

        public Working()
        {
            InitializeComponent();
        }

        private void Working_Load(object sender, EventArgs e)
        {
            Utils.DbSettings settings = Utils.ReadSettings();
            if (settings == null)
            {
                Utils.ShowError("Please configure Portable DNS Proxy before starting the proxy.");
                Close();
            }

            if (settings.ProxyType == Utils.DbProxyType.SystemDefault)
            {
                IWebProxy proxy = WebRequest.GetSystemWebProxy();

                if(proxy == null)
                {
                    settings.ProxyType = Utils.DbProxyType.None;
                }
                else
                {
                    lblProxyHostValue.Text = "System default";
                    lblProxyTypeValue.Text = "n/a";
                }
            }
            else if (settings.ProxyType != Utils.DbProxyType.None)
            {
                lblProxyHostValue.Text = settings.ProxyHost + ":" + settings.ProxyPort;
                lblProxyTypeValue.Text = settings.ProxyType.ToString().Replace("Http", "HTTP").Replace("Socks", "SOCKS");
            }

            Proxy = new DnsProxyServer(this, settings);
            totalTlsCertsInStore = Proxy.Certificates.Count;
            lblTlsCertsInStoreValue.Text = String.Format("{0:n0}", totalTlsCertsInStore);
            blockedTlsCerts = new List<string>();

            Thread serverThread = new Thread(new ThreadStart(Proxy.Start));
            serverThread.Start();
        }

        private void btnStopMe_Click(object sender, EventArgs e)
        {
            Proxy.Stop();
            Close();
        }

        private void Working_FormClosing(object sender, FormClosingEventArgs e)
        {
            Proxy.Stop();
        }

        readonly object syncLockRequestsReceived = new object();

        internal ulong AddReceivedRequestToStatistic()
        {
            ulong requestId;

            lock(syncLockRequestsReceived)
            {
                requestId = totalRequestsReceived++;
            }

            try
            {
                this.Invoke((Action)delegate
                {
                    lblRequestsReceivedValue.Text = String.Format("{0:n0}", totalRequestsReceived);
                });
            }
            catch
            {
                // Randomly throw when Working form has been closed, ignore
            }

            return requestId;
        }

        readonly object syncLockBytesAndTlsTunnels = new object();

        internal void AddServedRequestToStatistic(bool redirected, ulong bytesSend, ulong bytesReceived, bool tlsTunnelOpened = false)
        {
            lock (syncLockBytesAndTlsTunnels)
            {
                if (tlsTunnelOpened)
                {
                    totalTlsTunnelOpen++;
                }

                totalRequestsServed++;

                if (redirected)
                {
                    totalRequestsRedirected++;
                }

                totalBytesSent += bytesSend;
                totalBytesReceived += bytesReceived;
            }

            try
            {
                this.Invoke((Action)delegate
                {
                    lblRequestsServedValue.Text = String.Format("{0:n0}", totalRequestsServed);
                    lblRequestsRedirectedValue.Text = String.Format("{0:n0}", totalRequestsRedirected);
                    lblBytesSentValue.Text = String.Format("{0:n0}", totalBytesSent);
                    lblBytesReceivedValue.Text = String.Format("{0:n0}", totalBytesReceived);

                    if(tlsTunnelOpened)
                    {
                        lblTlsTunnelsOpenValue.Text = String.Format("{0:n0}", totalTlsTunnelOpen);
                    }
                });
            }
            catch (Exception)
            {
                // Randomly throw when Working form has been closed, ignore
            }
        }

        internal void AddTLSTunnelDataToStatistic(ulong bytesSend, ulong bytesReceived)
        {
            lock (syncLockBytesAndTlsTunnels)
            {
                totalBytesSent += bytesSend;
                totalBytesReceived += bytesReceived;
            }

            try
            {
                this.Invoke((Action)delegate
                {
                    lblBytesSentValue.Text = String.Format("{0:n0}", totalBytesSent);
                    lblBytesReceivedValue.Text = String.Format("{0:n0}", totalBytesReceived);
                });
            }
            catch (Exception)
            {
                // Randomly throw when Working form has been closed, ignore
            }
        }

        internal void AddClosedTLSTunnelToStatistic()
        {
            lock (syncLockBytesAndTlsTunnels)
            {
                --totalTlsTunnelOpen;
            }

            try
            {
                this.Invoke((Action)delegate
                {
                    lblTlsTunnelsOpenValue.Text = String.Format("{0:n0}", totalTlsTunnelOpen);
                });
            }
            catch (Exception)
            {
                // Randomly throw when Working form has been closed, ignore
            }
        }

        readonly object syncLockNewTlsCert = new object();

        internal void AddNewTlsCertToStatistic()
        {
            lock (syncLockNewTlsCert)
            {
                ++totalTlsCertsInStore;
                ++totalTlsCertsNew;
            }

            try
            {
                this.Invoke((Action)delegate
                {
                    lblTlsCertsInStoreValue.Text = String.Format("{0:n0}", totalTlsCertsInStore);
                    lblTlsCertsNewValue.Text = String.Format("{0:n0}", totalTlsCertsNew);
                });
            }
            catch (Exception)
            {
                // Randomly throw when Working form has been closed, ignore
            }
        }

        readonly object syncLockBlockedTlsCerts = new object();

        internal void SetTlsCertBlocked(string hostname, bool blocked)
        {
            lock (syncLockBlockedTlsCerts)
            {
                bool alreadyMarkedAsBlocked = blockedTlsCerts.Contains(hostname);

                if (blocked && alreadyMarkedAsBlocked ||
                    !blocked && !alreadyMarkedAsBlocked)
                {
                    return;
                }

                if (blocked && !alreadyMarkedAsBlocked)
                {
                    blockedTlsCerts.Add(hostname);
                }
                else if(!blocked && alreadyMarkedAsBlocked)
                {
                    blockedTlsCerts.Remove(hostname);
                }

                try
                {
                    this.Invoke((Action)delegate
                    {
                        int count = blockedTlsCerts.Count;
                        lblTlsCertsBlockedValue.Text = String.Format("{0:n0}", count);

                        if (count > 0 && !lblTlsCertsBlocked.Enabled)
                        {
                            lblTlsCertsBlocked.Enabled = true;
                            lblTlsCertsBlockedValue.Enabled = true;
                        }
                        else if(count == 0 && lblTlsCertsBlocked.Enabled)
                        {
                            lblTlsCertsBlocked.Enabled = false;
                            lblTlsCertsBlockedValue.Enabled = false;
                        }
                    });
                }
                catch (Exception)
                {
                    // Randomly throw when Working form has been closed, ignore
                }
            }
        }

        private void lblTlsCertsBlocked_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (DynamicMessagebox messageBox = new DynamicMessagebox())
            {
                messageBox.Text = "Blocked Domains";

                messageBox.AddLabel("The self signed certificates which Portable DNS Proxy created to proxy you to the following domains have been recognized as not yet been accepted by your browser: \n\n");

                foreach (string domain in blockedTlsCerts)
                {
                    messageBox.AddLinkLabel("   - " + domain, "https://" + domain);
                }

                messageBox.AddLabel("\nYou may be able to unblock them by directly opening the above links in your browser.");

                messageBox.Icon = SystemIcons.Shield.ToBitmap();

                messageBox.ShowDialog(this);
            }
        }
    }
}
