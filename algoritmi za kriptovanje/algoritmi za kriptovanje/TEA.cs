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
    public partial class TEA : Form
    {
        private string output;
        string encryptMessage;
        private string key;
        public TEA()
        {
            InitializeComponent();
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            String str = tbMessage.Text.ToString();
            key = tbKey.Text.ToString();
            Invoke(new Action(() => tbEncrypt.Clear()));
            encryptMessage = Encrypt(str);
            Invoke(new Action(() => tbEncrypt.AppendText(ToBinaryString(Encoding.UTF8, encryptMessage))));
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            String key = tbKey.Text.ToString();
            Invoke(new Action(() => tbDecrypt.Clear()));
            Invoke(new Action(() => tbDecrypt.AppendText(Decrypt(encryptMessage))));
        }

        private void Code(uint[] v, uint[] k)
        {
            uint y = v[0];
            uint z = v[1];
            uint sum = 0;
            uint delta = 0x9e3779b9;
            uint n = 32;

            while (n-- > 0)
            {
                y += (z << 4 ^ z >> 5) + z ^ sum + k[sum & 3];
                sum += delta;
                z += (y << 4 ^ y >> 5) + y ^ sum + k[sum >> 11 & 3];
            }

            v[0] = y;
            v[1] = z;
        }

        private void Decode(uint[] v, uint[] k)
        {
            uint n = 32;
            uint sum;
            uint y = v[0];
            uint z = v[1];
            uint delta = 0x9e3779b9;

            sum = delta << 5;

            while (n-- > 0)
            {
                z -= (y << 4 ^ y >> 5) + y ^ sum + k[sum >> 11 & 3];
                sum -= delta;
                y -= (z << 4 ^ z >> 5) + z ^ sum + k[sum & 3];
            }

            v[0] = y;
            v[1] = z;
        }

        public uint[] KeyChanging(string key)
        {
            key = key.PadRight(16, ' ').Substring(0, 16);
            uint[] keyWhitChange = new uint[4];
            int j = 0;
            for (int i = 0; i < key.Length; i += 4)
                keyWhitChange[j++] = ConvertStringToUInt(key.Substring(i, 4));

            return keyWhitChange;
        }

        public string Encrypt(string data)
        {
            uint[] formattedKey = KeyChanging(key);

            if (data.Length % 2 != 0) data += '\0';
            byte[] dataBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(data);

            string cipher = string.Empty;
            uint[] tempData = new uint[2];
            for (int i = 0; i < dataBytes.Length; i += 2)
            {
                tempData[0] = dataBytes[i];
                tempData[1] = dataBytes[i + 1];
                Code(tempData, formattedKey);
                cipher += InputChanging(tempData[0]) +
                                  InputChanging(tempData[1]);
            }

            return cipher;
        }

        public string Decrypt(string Data)
        {
            uint[] formattedKey = KeyChanging(key);
            int x = 0;
            uint[] tempData = new uint[2];
            byte[] dataBytes = new byte[Data.Length / 8 * 2];
            for (int i = 0; i < Data.Length; i += 8)
            {
                tempData[0] = ConvertStringToUInt(Data.Substring(i, 4));
                tempData[1] = ConvertStringToUInt(Data.Substring(i + 4, 4));
                Decode(tempData, formattedKey);
                dataBytes[x++] = (byte)tempData[0];
                dataBytes[x++] = (byte)tempData[1];
            }
            string deciphered = System.Text.ASCIIEncoding.ASCII.GetString(dataBytes, 0, dataBytes.Length);
            if (deciphered[deciphered.Length - 1] == '\0')
                deciphered = deciphered.Substring(0, deciphered.Length - 1);
            return deciphered;
        }

        private string InputChanging(uint x)
        {
            System.Text.StringBuilder xChanged = new System.Text.StringBuilder();
            xChanged.Append((char)((x & 0xFF)));
            xChanged.Append((char)((x >> 8) & 0xFF));
            xChanged.Append((char)((x >> 16) & 0xFF));
            xChanged.Append((char)((x >> 24) & 0xFF));
            return xChanged.ToString();
        }

        private uint ConvertStringToUInt(string x)
        {
            uint xChanged;
            xChanged = ((uint)x[0]);
            xChanged += ((uint)x[1] << 8);
            xChanged += ((uint)x[2] << 16);
            xChanged += ((uint)x[3] << 24);
            return xChanged;
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

        private void btnEncryptFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text|*.txt|All|*.*";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string message = File.ReadAllText(ofd.FileName);
                key = "randomkey";
                Invoke(new Action(() => tbEncrypt.Clear()));
                encryptMessage = Encrypt(message);
                String encryptedString = ToBinaryString(Encoding.UTF8, encryptMessage);
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
                key = "randomkey";//harkodirala sam key za citanje i upisivanje u fajl
                string decryptedString = Decrypt(encryptMessage);
                output = AppDomain.CurrentDomain.BaseDirectory + "decrypt\\" + ofd.SafeFileName;
                FileStream fs = File.Create(output);
                fs.Close();
                File.WriteAllText(output, decryptedString);
                MessageBox.Show("The file has been decrypted");
            }
        }
    }
}
