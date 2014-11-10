namespace PortableDnsProxy
{
    partial class ConfigHost
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigHost));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbxHostMatch = new System.Windows.Forms.TextBox();
            this.lblHostMatch = new System.Windows.Forms.Label();
            this.tbxHostRedirect = new System.Windows.Forms.TextBox();
            this.lblHostRedirect = new System.Windows.Forms.Label();
            this.tbxHostHeaderOverwrite = new System.Windows.Forms.TextBox();
            this.lblHostHeaderOverwrite = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Configure Host";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::PortableDnsProxy.Properties.Resources.portableDnsProxy;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(249, 61);
            this.panel1.TabIndex = 9;
            // 
            // tbxHostMatch
            // 
            this.tbxHostMatch.Location = new System.Drawing.Point(11, 98);
            this.tbxHostMatch.Name = "tbxHostMatch";
            this.tbxHostMatch.Size = new System.Drawing.Size(226, 20);
            this.tbxHostMatch.TabIndex = 11;
            // 
            // lblHostMatch
            // 
            this.lblHostMatch.AutoSize = true;
            this.lblHostMatch.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHostMatch.Location = new System.Drawing.Point(10, 78);
            this.lblHostMatch.Name = "lblHostMatch";
            this.lblHostMatch.Size = new System.Drawing.Size(79, 13);
            this.lblHostMatch.TabIndex = 12;
            this.lblHostMatch.Text = "Host to match";
            // 
            // tbxHostRedirect
            // 
            this.tbxHostRedirect.Location = new System.Drawing.Point(13, 144);
            this.tbxHostRedirect.Name = "tbxHostRedirect";
            this.tbxHostRedirect.Size = new System.Drawing.Size(226, 20);
            this.tbxHostRedirect.TabIndex = 13;
            // 
            // lblHostRedirect
            // 
            this.lblHostRedirect.AutoSize = true;
            this.lblHostRedirect.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHostRedirect.Location = new System.Drawing.Point(10, 124);
            this.lblHostRedirect.Name = "lblHostRedirect";
            this.lblHostRedirect.Size = new System.Drawing.Size(181, 13);
            this.lblHostRedirect.TabIndex = 14;
            this.lblHostRedirect.Text = "Redirect requests to this host or IP";
            // 
            // tbxHostHeaderOverwrite
            // 
            this.tbxHostHeaderOverwrite.Location = new System.Drawing.Point(11, 190);
            this.tbxHostHeaderOverwrite.Name = "tbxHostHeaderOverwrite";
            this.tbxHostHeaderOverwrite.Size = new System.Drawing.Size(226, 20);
            this.tbxHostHeaderOverwrite.TabIndex = 15;
            // 
            // lblHostHeaderOverwrite
            // 
            this.lblHostHeaderOverwrite.AutoSize = true;
            this.lblHostHeaderOverwrite.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHostHeaderOverwrite.Location = new System.Drawing.Point(10, 170);
            this.lblHostHeaderOverwrite.Name = "lblHostHeaderOverwrite";
            this.lblHostHeaderOverwrite.Size = new System.Drawing.Size(202, 13);
            this.lblHostHeaderOverwrite.TabIndex = 16;
            this.lblHostHeaderOverwrite.Text = "Rewrite HTTP host header to this value";
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Image = global::PortableDnsProxy.Properties.Resources.accept;
            this.btnSave.Location = new System.Drawing.Point(11, 220);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(117, 50);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::PortableDnsProxy.Properties.Resources.cancel;
            this.btnCancel.Location = new System.Drawing.Point(147, 220);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 50);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // ConfigHost
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(249, 283);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tbxHostHeaderOverwrite);
            this.Controls.Add(this.lblHostHeaderOverwrite);
            this.Controls.Add(this.tbxHostRedirect);
            this.Controls.Add(this.lblHostRedirect);
            this.Controls.Add(this.tbxHostMatch);
            this.Controls.Add(this.lblHostMatch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigHost";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Portable DNS Proxy - Configure Host";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblHostMatch;
        private System.Windows.Forms.Label lblHostRedirect;
        private System.Windows.Forms.Label lblHostHeaderOverwrite;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.TextBox tbxHostMatch;
        internal System.Windows.Forms.TextBox tbxHostRedirect;
        internal System.Windows.Forms.TextBox tbxHostHeaderOverwrite;
    }
}