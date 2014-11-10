namespace PortableDnsProxy
{
    partial class Working
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Working));
            this.btnStopMe = new System.Windows.Forms.Button();
            this.lblWorking = new System.Windows.Forms.Label();
            this.lblRequestsServed = new System.Windows.Forms.Label();
            this.lblRequestsRedirected = new System.Windows.Forms.Label();
            this.lblRequestsRedirectedValue = new System.Windows.Forms.Label();
            this.lblRequestsServedValue = new System.Windows.Forms.Label();
            this.lblBytesReceivedValue = new System.Windows.Forms.Label();
            this.lblBytesSentValue = new System.Windows.Forms.Label();
            this.lblBytesReceived = new System.Windows.Forms.Label();
            this.lblBytesSent = new System.Windows.Forms.Label();
            this.lblRequestsReceived = new System.Windows.Forms.Label();
            this.lblRequestsReceivedValue = new System.Windows.Forms.Label();
            this.lblTlsTunnelsOpen = new System.Windows.Forms.Label();
            this.lblTlsTunnelsOpenValue = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTlsCertsInStoreValue = new System.Windows.Forms.Label();
            this.lblTlsCertsInStore = new System.Windows.Forms.Label();
            this.lblTlsCertsNewValue = new System.Windows.Forms.Label();
            this.lblTlsCertsNew = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTlsCertsBlocked = new System.Windows.Forms.LinkLabel();
            this.lblTlsCertsBlockedValue = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblProxyHost = new System.Windows.Forms.Label();
            this.lblProxyHostValue = new System.Windows.Forms.Label();
            this.lblProxyTypeValue = new System.Windows.Forms.Label();
            this.lblProxyType = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnStopMe
            // 
            this.btnStopMe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStopMe.Image = global::PortableDnsProxy.Properties.Resources.disconnect;
            this.btnStopMe.Location = new System.Drawing.Point(219, 273);
            this.btnStopMe.Name = "btnStopMe";
            this.btnStopMe.Size = new System.Drawing.Size(81, 86);
            this.btnStopMe.TabIndex = 0;
            this.btnStopMe.Text = "Stop Proxy";
            this.btnStopMe.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnStopMe.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnStopMe.UseVisualStyleBackColor = true;
            this.btnStopMe.Click += new System.EventHandler(this.btnStopMe_Click);
            // 
            // lblWorking
            // 
            this.lblWorking.AutoSize = true;
            this.lblWorking.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWorking.Location = new System.Drawing.Point(10, 60);
            this.lblWorking.Name = "lblWorking";
            this.lblWorking.Size = new System.Drawing.Size(166, 13);
            this.lblWorking.TabIndex = 7;
            this.lblWorking.Text = "Portable DNS Proxy is running";
            // 
            // lblRequestsServed
            // 
            this.lblRequestsServed.AutoSize = true;
            this.lblRequestsServed.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequestsServed.Location = new System.Drawing.Point(10, 111);
            this.lblRequestsServed.Name = "lblRequestsServed";
            this.lblRequestsServed.Size = new System.Drawing.Size(122, 13);
            this.lblRequestsServed.TabIndex = 8;
            this.lblRequestsServed.Text = "HTTP Requests served:";
            // 
            // lblRequestsRedirected
            // 
            this.lblRequestsRedirected.AutoSize = true;
            this.lblRequestsRedirected.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequestsRedirected.Location = new System.Drawing.Point(10, 134);
            this.lblRequestsRedirected.Name = "lblRequestsRedirected";
            this.lblRequestsRedirected.Size = new System.Drawing.Size(180, 13);
            this.lblRequestsRedirected.TabIndex = 9;
            this.lblRequestsRedirected.Text = "HTTP Requests redirected thereof:";
            // 
            // lblRequestsRedirectedValue
            // 
            this.lblRequestsRedirectedValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRequestsRedirectedValue.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequestsRedirectedValue.Location = new System.Drawing.Point(200, 134);
            this.lblRequestsRedirectedValue.Name = "lblRequestsRedirectedValue";
            this.lblRequestsRedirectedValue.Size = new System.Drawing.Size(100, 13);
            this.lblRequestsRedirectedValue.TabIndex = 11;
            this.lblRequestsRedirectedValue.Text = "0";
            this.lblRequestsRedirectedValue.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblRequestsServedValue
            // 
            this.lblRequestsServedValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRequestsServedValue.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequestsServedValue.Location = new System.Drawing.Point(200, 111);
            this.lblRequestsServedValue.Name = "lblRequestsServedValue";
            this.lblRequestsServedValue.Size = new System.Drawing.Size(100, 13);
            this.lblRequestsServedValue.TabIndex = 10;
            this.lblRequestsServedValue.Text = "0";
            this.lblRequestsServedValue.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblBytesReceivedValue
            // 
            this.lblBytesReceivedValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBytesReceivedValue.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBytesReceivedValue.Location = new System.Drawing.Point(200, 180);
            this.lblBytesReceivedValue.Name = "lblBytesReceivedValue";
            this.lblBytesReceivedValue.Size = new System.Drawing.Size(100, 13);
            this.lblBytesReceivedValue.TabIndex = 15;
            this.lblBytesReceivedValue.Text = "0";
            this.lblBytesReceivedValue.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblBytesSentValue
            // 
            this.lblBytesSentValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBytesSentValue.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBytesSentValue.Location = new System.Drawing.Point(200, 157);
            this.lblBytesSentValue.Name = "lblBytesSentValue";
            this.lblBytesSentValue.Size = new System.Drawing.Size(100, 13);
            this.lblBytesSentValue.TabIndex = 14;
            this.lblBytesSentValue.Text = "0";
            this.lblBytesSentValue.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblBytesReceived
            // 
            this.lblBytesReceived.AutoSize = true;
            this.lblBytesReceived.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBytesReceived.Location = new System.Drawing.Point(10, 180);
            this.lblBytesReceived.Name = "lblBytesReceived";
            this.lblBytesReceived.Size = new System.Drawing.Size(87, 13);
            this.lblBytesReceived.TabIndex = 13;
            this.lblBytesReceived.Text = "Bytes Received:";
            // 
            // lblBytesSent
            // 
            this.lblBytesSent.AutoSize = true;
            this.lblBytesSent.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBytesSent.Location = new System.Drawing.Point(10, 157);
            this.lblBytesSent.Name = "lblBytesSent";
            this.lblBytesSent.Size = new System.Drawing.Size(62, 13);
            this.lblBytesSent.TabIndex = 12;
            this.lblBytesSent.Text = "Bytes sent:";
            // 
            // lblRequestsReceived
            // 
            this.lblRequestsReceived.AutoSize = true;
            this.lblRequestsReceived.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequestsReceived.Location = new System.Drawing.Point(10, 88);
            this.lblRequestsReceived.Name = "lblRequestsReceived";
            this.lblRequestsReceived.Size = new System.Drawing.Size(131, 13);
            this.lblRequestsReceived.TabIndex = 16;
            this.lblRequestsReceived.Text = "HTTP Requests received:";
            // 
            // lblRequestsReceivedValue
            // 
            this.lblRequestsReceivedValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRequestsReceivedValue.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequestsReceivedValue.Location = new System.Drawing.Point(200, 88);
            this.lblRequestsReceivedValue.Name = "lblRequestsReceivedValue";
            this.lblRequestsReceivedValue.Size = new System.Drawing.Size(100, 13);
            this.lblRequestsReceivedValue.TabIndex = 17;
            this.lblRequestsReceivedValue.Text = "0";
            this.lblRequestsReceivedValue.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblTlsTunnelsOpen
            // 
            this.lblTlsTunnelsOpen.AutoSize = true;
            this.lblTlsTunnelsOpen.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTlsTunnelsOpen.Location = new System.Drawing.Point(10, 273);
            this.lblTlsTunnelsOpen.Name = "lblTlsTunnelsOpen";
            this.lblTlsTunnelsOpen.Size = new System.Drawing.Size(137, 13);
            this.lblTlsTunnelsOpen.TabIndex = 18;
            this.lblTlsTunnelsOpen.Text = "TLS tunnel currently open:";
            // 
            // lblTlsTunnelsOpenValue
            // 
            this.lblTlsTunnelsOpenValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTlsTunnelsOpenValue.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTlsTunnelsOpenValue.Location = new System.Drawing.Point(179, 273);
            this.lblTlsTunnelsOpenValue.Name = "lblTlsTunnelsOpenValue";
            this.lblTlsTunnelsOpenValue.Size = new System.Drawing.Size(30, 13);
            this.lblTlsTunnelsOpenValue.TabIndex = 19;
            this.lblTlsTunnelsOpenValue.Text = "0";
            this.lblTlsTunnelsOpenValue.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(12, 262);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(288, 2);
            this.label1.TabIndex = 20;
            // 
            // lblTlsCertsInStoreValue
            // 
            this.lblTlsCertsInStoreValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTlsCertsInStoreValue.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTlsCertsInStoreValue.Location = new System.Drawing.Point(179, 296);
            this.lblTlsCertsInStoreValue.Name = "lblTlsCertsInStoreValue";
            this.lblTlsCertsInStoreValue.Size = new System.Drawing.Size(30, 13);
            this.lblTlsCertsInStoreValue.TabIndex = 22;
            this.lblTlsCertsInStoreValue.Text = "0";
            this.lblTlsCertsInStoreValue.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblTlsCertsInStore
            // 
            this.lblTlsCertsInStore.AutoSize = true;
            this.lblTlsCertsInStore.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTlsCertsInStore.Location = new System.Drawing.Point(10, 296);
            this.lblTlsCertsInStore.Name = "lblTlsCertsInStore";
            this.lblTlsCertsInStore.Size = new System.Drawing.Size(97, 13);
            this.lblTlsCertsInStore.TabIndex = 21;
            this.lblTlsCertsInStore.Text = "TLS certs in cache:";
            // 
            // lblTlsCertsNewValue
            // 
            this.lblTlsCertsNewValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTlsCertsNewValue.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTlsCertsNewValue.Location = new System.Drawing.Point(179, 319);
            this.lblTlsCertsNewValue.Name = "lblTlsCertsNewValue";
            this.lblTlsCertsNewValue.Size = new System.Drawing.Size(30, 13);
            this.lblTlsCertsNewValue.TabIndex = 24;
            this.lblTlsCertsNewValue.Text = "0";
            this.lblTlsCertsNewValue.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblTlsCertsNew
            // 
            this.lblTlsCertsNew.AutoSize = true;
            this.lblTlsCertsNew.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTlsCertsNew.Location = new System.Drawing.Point(10, 319);
            this.lblTlsCertsNew.Name = "lblTlsCertsNew";
            this.lblTlsCertsNew.Size = new System.Drawing.Size(77, 13);
            this.lblTlsCertsNew.TabIndex = 23;
            this.lblTlsCertsNew.Text = "TLS certs new:";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::PortableDnsProxy.Properties.Resources.portableDnsProxy;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(312, 61);
            this.panel1.TabIndex = 4;
            // 
            // lblTlsCertsBlocked
            // 
            this.lblTlsCertsBlocked.AutoSize = true;
            this.lblTlsCertsBlocked.Enabled = false;
            this.lblTlsCertsBlocked.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F);
            this.lblTlsCertsBlocked.Location = new System.Drawing.Point(10, 342);
            this.lblTlsCertsBlocked.Name = "lblTlsCertsBlocked";
            this.lblTlsCertsBlocked.Size = new System.Drawing.Size(98, 13);
            this.lblTlsCertsBlocked.TabIndex = 27;
            this.lblTlsCertsBlocked.TabStop = true;
            this.lblTlsCertsBlocked.Text = "TLS certs blocked:";
            this.lblTlsCertsBlocked.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblTlsCertsBlocked_LinkClicked);
            // 
            // lblTlsCertsBlockedValue
            // 
            this.lblTlsCertsBlockedValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTlsCertsBlockedValue.Enabled = false;
            this.lblTlsCertsBlockedValue.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F);
            this.lblTlsCertsBlockedValue.Location = new System.Drawing.Point(179, 342);
            this.lblTlsCertsBlockedValue.Name = "lblTlsCertsBlockedValue";
            this.lblTlsCertsBlockedValue.Size = new System.Drawing.Size(30, 13);
            this.lblTlsCertsBlockedValue.TabIndex = 28;
            this.lblTlsCertsBlockedValue.TabStop = true;
            this.lblTlsCertsBlockedValue.Text = "0";
            this.lblTlsCertsBlockedValue.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblTlsCertsBlockedValue.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblTlsCertsBlocked_LinkClicked);
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(12, 204);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(288, 2);
            this.label2.TabIndex = 29;
            // 
            // lblProxyHost
            // 
            this.lblProxyHost.AutoSize = true;
            this.lblProxyHost.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProxyHost.Location = new System.Drawing.Point(10, 215);
            this.lblProxyHost.Name = "lblProxyHost";
            this.lblProxyHost.Size = new System.Drawing.Size(71, 13);
            this.lblProxyHost.TabIndex = 30;
            this.lblProxyHost.Text = "Using Proxy:";
            // 
            // lblProxyHostValue
            // 
            this.lblProxyHostValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProxyHostValue.AutoEllipsis = true;
            this.lblProxyHostValue.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProxyHostValue.Location = new System.Drawing.Point(100, 215);
            this.lblProxyHostValue.Name = "lblProxyHostValue";
            this.lblProxyHostValue.Size = new System.Drawing.Size(200, 13);
            this.lblProxyHostValue.TabIndex = 31;
            this.lblProxyHostValue.Text = "No";
            this.lblProxyHostValue.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblProxyTypeValue
            // 
            this.lblProxyTypeValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProxyTypeValue.AutoEllipsis = true;
            this.lblProxyTypeValue.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProxyTypeValue.Location = new System.Drawing.Point(100, 238);
            this.lblProxyTypeValue.Name = "lblProxyTypeValue";
            this.lblProxyTypeValue.Size = new System.Drawing.Size(200, 13);
            this.lblProxyTypeValue.TabIndex = 33;
            this.lblProxyTypeValue.Text = "n/a";
            this.lblProxyTypeValue.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblProxyType
            // 
            this.lblProxyType.AutoSize = true;
            this.lblProxyType.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProxyType.Location = new System.Drawing.Point(10, 238);
            this.lblProxyType.Name = "lblProxyType";
            this.lblProxyType.Size = new System.Drawing.Size(65, 13);
            this.lblProxyType.TabIndex = 32;
            this.lblProxyType.Text = "Proxy type:";
            // 
            // Working
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 371);
            this.Controls.Add(this.lblProxyTypeValue);
            this.Controls.Add(this.lblProxyType);
            this.Controls.Add(this.lblProxyHostValue);
            this.Controls.Add(this.lblProxyHost);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTlsCertsBlockedValue);
            this.Controls.Add(this.lblTlsCertsBlocked);
            this.Controls.Add(this.lblTlsCertsNewValue);
            this.Controls.Add(this.lblTlsCertsNew);
            this.Controls.Add(this.lblTlsCertsInStoreValue);
            this.Controls.Add(this.lblTlsCertsInStore);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTlsTunnelsOpenValue);
            this.Controls.Add(this.lblTlsTunnelsOpen);
            this.Controls.Add(this.lblRequestsReceivedValue);
            this.Controls.Add(this.lblRequestsReceived);
            this.Controls.Add(this.lblBytesReceivedValue);
            this.Controls.Add(this.lblBytesSentValue);
            this.Controls.Add(this.lblBytesReceived);
            this.Controls.Add(this.lblBytesSent);
            this.Controls.Add(this.lblRequestsRedirectedValue);
            this.Controls.Add(this.lblRequestsServedValue);
            this.Controls.Add(this.lblRequestsRedirected);
            this.Controls.Add(this.lblRequestsServed);
            this.Controls.Add(this.lblWorking);
            this.Controls.Add(this.btnStopMe);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Working";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Portable DNS Proxy - Proxy running";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Working_FormClosing);
            this.Load += new System.EventHandler(this.Working_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnStopMe;
        private System.Windows.Forms.Label lblWorking;
        private System.Windows.Forms.Label lblRequestsServed;
        private System.Windows.Forms.Label lblRequestsRedirected;
        private System.Windows.Forms.Label lblBytesReceived;
        private System.Windows.Forms.Label lblBytesSent;
        private System.Windows.Forms.Label lblBytesReceivedValue;
        private System.Windows.Forms.Label lblBytesSentValue;
        private System.Windows.Forms.Label lblRequestsRedirectedValue;
        private System.Windows.Forms.Label lblRequestsServedValue;
        private System.Windows.Forms.Label lblRequestsReceived;
        private System.Windows.Forms.Label lblRequestsReceivedValue;
        private System.Windows.Forms.Label lblTlsTunnelsOpen;
        private System.Windows.Forms.Label lblTlsTunnelsOpenValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTlsCertsInStoreValue;
        private System.Windows.Forms.Label lblTlsCertsInStore;
        private System.Windows.Forms.Label lblTlsCertsNewValue;
        private System.Windows.Forms.Label lblTlsCertsNew;
        private System.Windows.Forms.LinkLabel lblTlsCertsBlocked;
        private System.Windows.Forms.LinkLabel lblTlsCertsBlockedValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblProxyHost;
        private System.Windows.Forms.Label lblProxyHostValue;
        private System.Windows.Forms.Label lblProxyTypeValue;
        private System.Windows.Forms.Label lblProxyType;
    }
}