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
        public int didgeridoos = 100;
        Timer t = new Timer();
        public Main()
        {
            InitializeComponent();

            TimeSpan second = TimeSpan.FromSeconds(1);
            TimeSpan time = TimeSpan.FromHours(48);
            t.Interval = 1000;
            t.Tick += delegate
            {
                time = time.Subtract(second);

                labelTime.Text = String.Format("TIME LEFT: {0}h {1:00}m {2:00}s", (int)Math.Floor(time.TotalHours), time.Minutes, time.Seconds);
            };
            t.Start();

            emergency.Parent = pictureBox1;
            emergency.MouseDown += delegate(object sender, MouseEventArgs e)
            {
                if(e.Button == System.Windows.Forms.MouseButtons.Right)
                    btnNext.Enabled = true;
            };

            dp = new Deposit(this);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.Focus();
        }

        public void UpdateDidgeridoos()
        {
            txtDidgeridoos.Text = String.Format("{0} didgeridoos", (didgeridoos < 1 ? 0 : didgeridoos));

            if (didgeridoos < 1)
            {
                btnNext.Enabled = true;

                t.Stop();
                labelTime.Text = "COMPLETED";
            }
        }

        Deposit dp;
        private void btnDeposit_Click(object sender, EventArgs e)
        {
            dp.ShowDialog();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void WndProc(ref Message message)
        {

            switch (message.Msg)
            {
                case WinAPI.WM_SYSCOMMAND:
                    int command = message.WParam.ToInt32() & 0xfff0;
                    if (command == WinAPI.SC_MOVE)
                        return;
                    break;
            }

            base.WndProc(ref message);
        }
    }
}
