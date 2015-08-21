using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace DUMB
{
    public partial class CryptWindow : Form
    {
        string[] files = null;
        bool decrypt = false;
        public CryptWindow(bool decrypt)
        {
            this.decrypt = decrypt;

            InitializeComponent();

            if (decrypt) label.Text = "Decrypting files...";

            progress.MouseDown += delegate(object sender, MouseEventArgs e)
            {
                if (e.Button != System.Windows.Forms.MouseButtons.Right) return;
                if (MessageBox.Show("Close crypter?", "Info", MessageBoxButtons.YesNo) != System.Windows.Forms.DialogResult.Yes) return;
                this.Close();
            };

            files = Directory.GetFiles(Program.folder);

            progress.Maximum = files.Length;
        }

        private void CryptWindow_Load(object sender, EventArgs e)
        {
            BackgroundWorker back = new BackgroundWorker();
            back.DoWork += delegate
            {
                ISAAC csprng = Crypt.PrepareKey();
                if (csprng == null) return;
                foreach (string file in files)
                {
                    if (Path.GetFileName(file) == "crypted") continue;
                    Crypt.CryptFile(csprng, new byte[] { 0x54, 0x45, 0x53, 0x54, 0x4B, 0x45, 0x59 }, file);
                    progress.Invoke((Action)delegate { progress.Value++; });
                }
            };
            back.RunWorkerCompleted += delegate
            {
                if (!decrypt && !File.Exists(Program.folder + "crypted")) File.Create(Program.folder + "crypted").Close();
                else if (File.Exists(Program.folder + "crypted")) File.Delete(Program.folder + "crypted");
                this.Close();
            };
            back.RunWorkerAsync();
        }

        delegate void Action();
    }
}
