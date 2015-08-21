using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DUMB
{
    public partial class Deposit : Form
    {
        int didgeridoos = 100;
        Main main;
        public Deposit(Main m)
        {
            main = m;

            InitializeComponent();

            history.Items.Insert(0, new ListViewItem(new string[] { "Trip to Australia", "+300 didgeridoos" }));
            history.Items.Insert(0, new ListViewItem(new string[] { "Sent to mom", "-100 didgeridoos" }));
            history.Items.Insert(0, new ListViewItem(new string[] { "Sent to friend", "-100 didgeridoos" }));
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txtAddress.Text != "1DUMBcVysimeMnMxThLLtpsnVbbz3VoJTy")
            {
                MessageBox.Show("Incorrect address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int am = (int)amount.Value;
            if (am > didgeridoos)
            {
                MessageBox.Show("You do not have sufficient didgeridoos for that transaction.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            didgeridoos -= am;
            main.didgeridoos -= am;

            main.UpdateDidgeridoos();

            this.Text = String.Format("Send | Balance: {0}", didgeridoos);

            history.Items.Insert(0, new ListViewItem(new string[] { "Sent to leet haker", String.Format("-{0} didgeridoos", am) }));
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
