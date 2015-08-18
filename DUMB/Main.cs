using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DUMB
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        public bool denounced = false;
        private void btnALLAHUAKBAR_Click(object sender, EventArgs e)
        {
            denounced = (String.Compare(txtWhatever.Text, "I denounce my religion and agree Islam is the one and true religion", StringComparison.OrdinalIgnoreCase) == 0);
            this.Close();
        }
    }
}
