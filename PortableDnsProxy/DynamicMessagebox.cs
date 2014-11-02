using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PortableDnsProxy
{
    public partial class DynamicMessagebox : Form
    {
        public DynamicMessagebox()
        {
            InitializeComponent();

            pnlIcon.BackgroundImage = SystemIcons.Information.ToBitmap();
        }

        public new Image Icon
        {
            get
            {
                return pnlIcon.BackgroundImage;
            }

            set
            {
                pnlIcon.BackgroundImage = value;
            }
        }

        public void AddLabel(string text)
        {
            Label label = new Label();
            label.AutoSize = true;
            label.Dock = System.Windows.Forms.DockStyle.Top;
            label.MaximumSize = new System.Drawing.Size(Width - pnlMessage.Padding.Horizontal, 0);
            label.Text = text;

            pnlMessage.Controls.Add(label);
            pnlMessage.Controls.SetChildIndex(label, 0);
            AdjustSize();
        }

        public void AddLinkLabel(string text, string link)
        {
            LinkLabel label = new LinkLabel();
            label.AutoSize = true;
            label.Dock = System.Windows.Forms.DockStyle.Top;
            label.MaximumSize = new System.Drawing.Size(Width - pnlMessage.Padding.Horizontal, 0);
            label.Text = text;
            label.Tag = link;
            label.LinkBehavior = LinkBehavior.NeverUnderline;
            label.Click += label_Click;

            pnlMessage.Controls.Add(label);
            pnlMessage.Controls.SetChildIndex(label, 0);
            AdjustSize();
        }

        private void AdjustSize()
        {
            int requiredHeight = pnlMessage.Padding.Vertical + pnlButtons.Height;

            foreach(Control control in pnlMessage.Controls)
            {
                requiredHeight += control.Height;
            }

            Height = requiredHeight;
        }

        private void label_Click(object sender, EventArgs e)
        {
            string url = (string)((LinkLabel)sender).Tag;

            try
            {
                Process.Start(url);
            }
            catch (Exception)
            {
                Utils.ShowError("The link could not be opened.\n\n " + url,
                                "Could not open your browser.");
            }
        }
    }
}
