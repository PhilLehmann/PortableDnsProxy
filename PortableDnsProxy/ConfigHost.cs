using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PortableDnsProxy
{
    public partial class ConfigHost : Form
    {
        public ConfigHost()
        {
            InitializeComponent();
        }

        public ConfigHost(string originalName, string redirectedNameOrIp, string rewrittenHostHeader) :
            this()
        {
            tbxHostMatch.Text = originalName;
            tbxHostRedirect.Text = redirectedNameOrIp;
            tbxHostHeaderOverwrite.Text = rewrittenHostHeader;
        }
    }
}
