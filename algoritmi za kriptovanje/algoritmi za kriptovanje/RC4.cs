using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace _17969_Jovana_Stepanovic
{
    public partial class RC4 : Form
    {
        string encryptedString;
        private string output;
        byte[] encryptBytes;
        byte[] encryptedBytes;

        public RC4()
        {
            InitializeComponent();
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            String plaintext = tbMessage.Text.ToString();
            String key = tbKey.Text.ToString();
            if (key == null) MessageBox.Show("You must enter a key!");
            encryptBytes = encrypt(plaintext, key);

            Invoke(new Action(() => tbEncrypt.Clear()));
            Invoke(new Action(() => tbEncrypt.AppendText(ToBinaryString(Encoding.UTF8, Encoding.ASCII.GetString(encryptBytes)))));

        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            String key = tbKey.Text.ToString();

            Invoke(new Action(() => tbDecrypt.Clear()));
            Invoke(new Action(() => tbDecrypt.AppendText(Encoding.ASCII.GetString(decrypt(key)))));
        }

        static string ToBinaryString(Encoding encoding, string text)
        {
            return string.Join("", encoding.GetBytes(text).Select(n => Convert.ToString(n, 2).PadLeft(8, '0')));
        }

        static string BinaryToString(string data)
        {
            List<Byte> byteList = new List<Byte>();

            for (int i = 0; i < data.Length; i += 8)
            {
                byteList.Add(Convert.ToByte(data.Substring(i, 8), 2));
            }
            return Encoding.ASCII.GetString(byteList.ToArray());
        }

        static byte[] PseudoRandomRc4(int[] sBox, byte[] messageBytes)
        {
            var i = 0;
            var j = 0;
            var cnt = 0;
            var tempBox = new int[sBox.Length];
            var result = new byte[messageBytes.Length];

            Array.Copy(sBox, tempBox, tempBox.Length);

            foreach (var textByte in messageBytes)
            {
                i = (i + 1) % 256;
                j = (j + tempBox[i]) % 256;
                var temp = tempBox[i];
                tempBox[i] = tempBox[j];
                tempBox[j] = temp;
                var t = (tempBox[i] + tempBox[j]) % 256;
                var k = tempBox[t];

                var ss = textByte ^ k;
                result[cnt] = (byte)ss;
                cnt++;
            }
            return result;
        }

        private byte[] encrypt(string plaintext, string key)
        {
            var asciiKeyBytes = Encoding.ASCII.GetBytes(key);
            var sBox = Enumerable.Range(0, 256).ToArray();

            var j = 0;
            for (var i = 0; i < 256; i++)
            {
                j = (j + sBox[i] + asciiKeyBytes[i % asciiKeyBytes.Length]) % 256;
                sBox[j] = sBox[i];
                sBox[i] = j;
            }

            var encryptBytes = PseudoRandomRc4(sBox, Encoding.ASCII.GetBytes(plaintext));
            return encryptBytes;
        }

        private byte[] decrypt(string key)
        {
            var asciiKeyBytes = Encoding.ASCII.GetBytes(key);
            var sBox = Enumerable.Range(0, 256).ToArray();

            var j = 0;
            for (var i = 0; i < 256; i++)
            {
                j = (j + sBox[i] + asciiKeyBytes[i % asciiKeyBytes.Length]) % 256;
                sBox[j] = sBox[i];
                sBox[i] = j;
            }
            return PseudoRandomRc4(sBox, encryptBytes);
        }

        private void btnEncryptFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text|*.txt|All|*.*";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string message = File.ReadAllText(ofd.FileName);

                String key = "randomKey";
                encryptBytes = encrypt(message, key);
                encryptedString = ToBinaryString(Encoding.UTF8, Encoding.ASCII.GetString(encryptBytes));                //END
               

                output = AppDomain.CurrentDomain.BaseDirectory + "encrypt\\" + ofd.SafeFileName;
                FileStream fs = File.Create(output);
                fs.Close();
                File.WriteAllText(output, encryptedString);
                MessageBox.Show("The file has been crypted");
            }
        }

        private void btnDecryptFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text|*.txt|All|*.*";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string ul = File.ReadAllText(ofd.FileName);
                encryptedBytes = Encoding.ASCII.GetBytes(ul);

                String key = "randomKey";
                String decryptedString = Encoding.ASCII.GetString(decrypt(key));

                output = AppDomain.CurrentDomain.BaseDirectory + "decrypt\\" + ofd.SafeFileName;
                FileStream fs = File.Create(output);
                fs.Close();
                File.WriteAllText(output, decryptedString);
                MessageBox.Show("The file has been decrypted");
            }
        }
    }
}
