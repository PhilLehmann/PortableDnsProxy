using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PortableDnsProxy
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Shown(object sender, EventArgs e)
        {
            if (Utils.ReadSettings() != null)
            {
                btnStartMe.Enabled = true;
                btnStartMe.Focus();
            }
            else
            {
                btnStartMe.Enabled = false;
            }
        }

        private void btnReadMe_Click(object sender, EventArgs e)
        {
            string url = "https://github.com/philrykoff/PortableDnsProxy/blob/master/readme.md";

            try
            {
                Process.Start(url);
            }
            catch (Exception)
            {
                Utils.ShowError("The read me file could not be opened automatically.\n\n " + url + ".\n\nSorry!",
                                "Could not open the read me.");
            }
        }

        private void btnConfigureMe_Click(object sender, EventArgs e)
        {
            using(Config frmConfig = new Config())
            {
                frmConfig.ShowDialog(this);

                if (Utils.ReadSettings() == null)
                {
                    btnStartMe.Enabled = false;
                }
                else
                {
                    btnStartMe.Enabled = true;
                }
            }
        }

        private void btnStartMe_Click(object sender, EventArgs e)
        {
            using (Working frmWorking = new Working())
            {
                Hide();

                frmWorking.ShowDialog(this);

                Show();
            }
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
