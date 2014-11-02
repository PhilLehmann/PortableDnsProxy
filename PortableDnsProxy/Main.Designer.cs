namespace PortableDnsProxy
{
    partial class Main
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.btnReadMe = new System.Windows.Forms.Button();
            this.btnStartMe = new System.Windows.Forms.Button();
            this.btnConfigureMe = new System.Windows.Forms.Button();
            this.lblMain = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnReadMe
            // 
            this.btnReadMe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReadMe.Image = global::PortableDnsProxy.Properties.Resources.blackboard_sum;
            this.btnReadMe.Location = new System.Drawing.Point(11, 81);
            this.btnReadMe.Name = "btnReadMe";
            this.btnReadMe.Size = new System.Drawing.Size(90, 70);
            this.btnReadMe.TabIndex = 1;
            this.btnReadMe.Text = "Readme";
            this.btnReadMe.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnReadMe.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnReadMe.UseVisualStyleBackColor = true;
            this.btnReadMe.Click += new System.EventHandler(this.btnReadMe_Click);
            // 
            // btnStartMe
            // 
            this.btnStartMe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStartMe.Enabled = false;
            this.btnStartMe.Image = global::PortableDnsProxy.Properties.Resources.connect;
            this.btnStartMe.Location = new System.Drawing.Point(203, 81);
            this.btnStartMe.Name = "btnStartMe";
            this.btnStartMe.Size = new System.Drawing.Size(90, 70);
            this.btnStartMe.TabIndex = 3;
            this.btnStartMe.Text = "Start Proxy";
            this.btnStartMe.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnStartMe.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnStartMe.UseVisualStyleBackColor = true;
            this.btnStartMe.Click += new System.EventHandler(this.btnStartMe_Click);
            // 
            // btnConfigureMe
            // 
            this.btnConfigureMe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfigureMe.Image = global::PortableDnsProxy.Properties.Resources.cog;
            this.btnConfigureMe.Location = new System.Drawing.Point(107, 81);
            this.btnConfigureMe.Name = "btnConfigureMe";
            this.btnConfigureMe.Size = new System.Drawing.Size(90, 70);
            this.btnConfigureMe.TabIndex = 2;
            this.btnConfigureMe.Text = "Configuration";
            this.btnConfigureMe.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnConfigureMe.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnConfigureMe.UseVisualStyleBackColor = true;
            this.btnConfigureMe.Click += new System.EventHandler(this.btnConfigureMe_Click);
            // 
            // lblMain
            // 
            this.lblMain.AutoSize = true;
            this.lblMain.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMain.Location = new System.Drawing.Point(10, 57);
            this.lblMain.Name = "lblMain";
            this.lblMain.Size = new System.Drawing.Size(68, 13);
            this.lblMain.TabIndex = 6;
            this.lblMain.Text = "Main Menu";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::PortableDnsProxy.Properties.Resources.portableDnsProxy;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(402, 61);
            this.panel1.TabIndex = 3;
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Image = global::PortableDnsProxy.Properties.Resources.door_in;
            this.btnClose.Location = new System.Drawing.Point(299, 81);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 70);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Main
            // 
            this.AcceptButton = this.btnStartMe;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 162);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblMain);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnConfigureMe);
            this.Controls.Add(this.btnStartMe);
            this.Controls.Add(this.btnReadMe);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Portable DNS Proxy";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Shown += new System.EventHandler(this.Main_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReadMe;
        private System.Windows.Forms.Button btnStartMe;
        private System.Windows.Forms.Button btnConfigureMe;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblMain;
        private System.Windows.Forms.Button btnClose;
    }
}

