namespace PortableDnsProxy
{
    partial class Config
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Config));
            this.dgvHosts = new System.Windows.Forms.DataGridView();
            this.colHostname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHostnameRedirected = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHostnameRewritten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRemoveHost = new System.Windows.Forms.Button();
            this.btnSaveAndClose = new System.Windows.Forms.Button();
            this.btnAddHost = new System.Windows.Forms.Button();
            this.lblHosts = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.tbxPort = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClearTlsCertificateCache = new System.Windows.Forms.Button();
            this.tbxProxyHost = new System.Windows.Forms.TextBox();
            this.lblProxy = new System.Windows.Forms.Label();
            this.cbxProxyType = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHosts)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvHosts
            // 
            this.dgvHosts.AllowUserToAddRows = false;
            this.dgvHosts.AllowUserToDeleteRows = false;
            this.dgvHosts.AllowUserToResizeRows = false;
            this.dgvHosts.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dgvHosts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHosts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colHostname,
            this.colHostnameRedirected,
            this.colHostnameRewritten});
            this.dgvHosts.Location = new System.Drawing.Point(12, 191);
            this.dgvHosts.MultiSelect = false;
            this.dgvHosts.Name = "dgvHosts";
            this.dgvHosts.ReadOnly = true;
            this.dgvHosts.RowHeadersVisible = false;
            this.dgvHosts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHosts.Size = new System.Drawing.Size(392, 165);
            this.dgvHosts.TabIndex = 3;
            this.dgvHosts.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHosts_CellDoubleClick);
            // 
            // colHostname
            // 
            this.colHostname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colHostname.HeaderText = "Host to match";
            this.colHostname.Name = "colHostname";
            this.colHostname.ReadOnly = true;
            // 
            // colHostnameRedirected
            // 
            this.colHostnameRedirected.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colHostnameRedirected.HeaderText = "Redirected to...";
            this.colHostnameRedirected.Name = "colHostnameRedirected";
            this.colHostnameRedirected.ReadOnly = true;
            // 
            // colHostnameRewritten
            // 
            this.colHostnameRewritten.HeaderText = "Rewritten to...";
            this.colHostnameRewritten.Name = "colHostnameRewritten";
            this.colHostnameRewritten.ReadOnly = true;
            // 
            // btnRemoveHost
            // 
            this.btnRemoveHost.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemoveHost.Image = global::PortableDnsProxy.Properties.Resources.computer_delete;
            this.btnRemoveHost.Location = new System.Drawing.Point(107, 365);
            this.btnRemoveHost.Name = "btnRemoveHost";
            this.btnRemoveHost.Size = new System.Drawing.Size(90, 70);
            this.btnRemoveHost.TabIndex = 5;
            this.btnRemoveHost.Text = "Remove Host";
            this.btnRemoveHost.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRemoveHost.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRemoveHost.UseVisualStyleBackColor = true;
            this.btnRemoveHost.Click += new System.EventHandler(this.btnRemoveHost_Click);
            // 
            // btnSaveAndClose
            // 
            this.btnSaveAndClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveAndClose.Image = global::PortableDnsProxy.Properties.Resources.disk;
            this.btnSaveAndClose.Location = new System.Drawing.Point(315, 365);
            this.btnSaveAndClose.Name = "btnSaveAndClose";
            this.btnSaveAndClose.Size = new System.Drawing.Size(90, 70);
            this.btnSaveAndClose.TabIndex = 7;
            this.btnSaveAndClose.Text = "Save && Close";
            this.btnSaveAndClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSaveAndClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSaveAndClose.UseVisualStyleBackColor = true;
            this.btnSaveAndClose.Click += new System.EventHandler(this.btnSaveAndClose_Click);
            // 
            // btnAddHost
            // 
            this.btnAddHost.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddHost.Image = global::PortableDnsProxy.Properties.Resources.computer_add;
            this.btnAddHost.Location = new System.Drawing.Point(11, 365);
            this.btnAddHost.Name = "btnAddHost";
            this.btnAddHost.Size = new System.Drawing.Size(90, 70);
            this.btnAddHost.TabIndex = 4;
            this.btnAddHost.Text = "Add Host";
            this.btnAddHost.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAddHost.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAddHost.UseVisualStyleBackColor = true;
            this.btnAddHost.Click += new System.EventHandler(this.btnAddHost_Click);
            // 
            // lblHosts
            // 
            this.lblHosts.AutoSize = true;
            this.lblHosts.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHosts.Location = new System.Drawing.Point(10, 171);
            this.lblHosts.Name = "lblHosts";
            this.lblHosts.Size = new System.Drawing.Size(151, 13);
            this.lblHosts.TabIndex = 4;
            this.lblHosts.Text = "Hosts which will be rewritten";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPort.Location = new System.Drawing.Point(10, 78);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(186, 13);
            this.lblPort.TabIndex = 5;
            this.lblPort.Text = "Port of Portable DNS Proxy\'s proxy";
            // 
            // tbxPort
            // 
            this.tbxPort.Location = new System.Drawing.Point(11, 98);
            this.tbxPort.Name = "tbxPort";
            this.tbxPort.Size = new System.Drawing.Size(394, 20);
            this.tbxPort.TabIndex = 0;
            this.tbxPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::PortableDnsProxy.Properties.Resources.portableDnsProxy;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(417, 61);
            this.panel1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Configuration";
            // 
            // btnClearTlsCertificateCache
            // 
            this.btnClearTlsCertificateCache.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearTlsCertificateCache.Enabled = false;
            this.btnClearTlsCertificateCache.Image = global::PortableDnsProxy.Properties.Resources.database_lightning;
            this.btnClearTlsCertificateCache.Location = new System.Drawing.Point(219, 365);
            this.btnClearTlsCertificateCache.Name = "btnClearTlsCertificateCache";
            this.btnClearTlsCertificateCache.Size = new System.Drawing.Size(90, 70);
            this.btnClearTlsCertificateCache.TabIndex = 6;
            this.btnClearTlsCertificateCache.Text = "Clear CertCache";
            this.btnClearTlsCertificateCache.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnClearTlsCertificateCache.UseVisualStyleBackColor = true;
            this.btnClearTlsCertificateCache.Click += new System.EventHandler(this.btnClearTlsCertificateCache_Click);
            // 
            // tbxProxyHost
            // 
            this.tbxProxyHost.Enabled = false;
            this.tbxProxyHost.Location = new System.Drawing.Point(141, 144);
            this.tbxProxyHost.Name = "tbxProxyHost";
            this.tbxProxyHost.Size = new System.Drawing.Size(264, 20);
            this.tbxProxyHost.TabIndex = 2;
            this.tbxProxyHost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblProxy
            // 
            this.lblProxy.AutoSize = true;
            this.lblProxy.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProxy.Location = new System.Drawing.Point(10, 124);
            this.lblProxy.Name = "lblProxy";
            this.lblProxy.Size = new System.Drawing.Size(208, 13);
            this.lblProxy.TabIndex = 10;
            this.lblProxy.Text = "Proxy for outgoing requests (host:port)";
            // 
            // cbxProxyType
            // 
            this.cbxProxyType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbxProxyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxProxyType.FormattingEnabled = true;
            this.cbxProxyType.Items.AddRange(new object[] {
            "None",
            "System default",
            "HTTP",
            "SOCKS4",
            "SOCKS4a",
            "SOCKS5"});
            this.cbxProxyType.Location = new System.Drawing.Point(11, 144);
            this.cbxProxyType.Name = "cbxProxyType";
            this.cbxProxyType.Size = new System.Drawing.Size(123, 21);
            this.cbxProxyType.TabIndex = 1;
            this.cbxProxyType.SelectedIndexChanged += new System.EventHandler(this.cbxProxyType_SelectedIndexChanged);
            // 
            // Config
            // 
            this.AcceptButton = this.btnSaveAndClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 447);
            this.Controls.Add(this.cbxProxyType);
            this.Controls.Add(this.tbxProxyHost);
            this.Controls.Add(this.lblProxy);
            this.Controls.Add(this.btnClearTlsCertificateCache);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tbxPort);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.lblHosts);
            this.Controls.Add(this.btnAddHost);
            this.Controls.Add(this.btnSaveAndClose);
            this.Controls.Add(this.btnRemoveHost);
            this.Controls.Add(this.dgvHosts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Config";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Portable DNS Proxy - Configuration";
            this.Load += new System.EventHandler(this.Config_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHosts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHosts;
        private System.Windows.Forms.Button btnRemoveHost;
        private System.Windows.Forms.Button btnSaveAndClose;
        private System.Windows.Forms.Button btnAddHost;
        private System.Windows.Forms.Label lblHosts;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TextBox tbxPort;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClearTlsCertificateCache;
        private System.Windows.Forms.TextBox tbxProxyHost;
        private System.Windows.Forms.Label lblProxy;
        private System.Windows.Forms.ComboBox cbxProxyType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHostname;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHostnameRedirected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHostnameRewritten;
    }
}