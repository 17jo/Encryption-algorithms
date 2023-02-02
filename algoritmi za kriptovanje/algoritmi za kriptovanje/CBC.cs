using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
using System.Collections;
using System.Runtime.InteropServices;

namespace _17969_Jovana_Stepanovic
{
    public partial class CBC : Form
    {
        private string output;
        string encryptedString;
        public static string key = "J/PYjc1ftDFK5+77U1PB80v2TamokGap5yCIP2YI6tQ=";
        public static string iv = "gaOr3uvhZEwFeSbRHwlHcg==";
        private string strIV = "abcdefghijklmnmo";
        private string strKey = "abcdefghijklmnmoabcdefghijklmnmo";
        public CBC()
        {
            InitializeComponent();
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            String str = tbMessage.Text.ToString();
            AesUtility aes = new AesUtility(key);

            encryptedString = aes.Encrypt(str, iv);

            Invoke(new Action(() => tbEncrypt.Clear()));
            Invoke(new Action(() => tbEncrypt.AppendText(ToBinaryString(Encoding.UTF8, encryptedString))));
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            String str = tbMessage.Text.ToString();
            AesUtility aes = new AesUtility(key);

            string decryptedString = aes.Decrypt(encryptedString, iv);

            Invoke(new Action(() => tbDecrypt.Clear()));
            Invoke(new Action(() => tbDecrypt.AppendText(decryptedString)));
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

        public class AesUtility
        {
            readonly byte[] key;

            public AesUtility(string base64key)
            {
                this.key = Convert.FromBase64String(base64key);
            }

            public static string GenerateIV()
            {
                var rijndaelManaged = new RijndaelManaged();

                rijndaelManaged.GenerateIV();

                return Convert.ToBase64String(rijndaelManaged.IV);
            }

            public string Encrypt(string plainString, string base64IV)
            {
                var rijndael = new RijndaelManaged
                {
                    BlockSize = 128,
                    Key = key,
                    IV = Convert.FromBase64String(base64IV),
                };

                var encryptor = rijndael.CreateEncryptor();

                byte[] bytes = Encoding.UTF8.GetBytes(plainString);

                return Convert.ToBase64String(encryptor.TransformFinalBlock(bytes, 0, bytes.Length));
            }

            public string Decrypt(string base64Encrypted, string base64IV)
            {
                var rijndael = new RijndaelManaged
                {
                    BlockSize = 128,
                    Key = key,
                    IV = Convert.FromBase64String(base64IV),
                };

                var decryptor = rijndael.CreateDecryptor();

                byte[] bytes = Convert.FromBase64String(base64Encrypted);

                return Encoding.UTF8.GetString(decryptor.TransformFinalBlock(bytes, 0, bytes.Length));
            }

            public static string GenerateNewKey()
            {
                var rijndael = new RijndaelManaged
                {
                    Mode = CipherMode.CBC,
                    KeySize = 256,
                    BlockSize = 128
                };

                rijndael.GenerateKey();

                return Convert.ToBase64String(rijndael.Key);
            }

            public string GenerateNewIv()
            {
                var rijndael = new RijndaelManaged
                {
                    Mode = CipherMode.CBC,
                    KeySize = 256,
                    BlockSize = 128
                };

                rijndael.GenerateIV();

                return Convert.ToBase64String(rijndael.IV);
            }
        }

        private void btnEncryptFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text|*.txt|All|*.*";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string message = File.ReadAllText(ofd.FileName);
                AesUtility aes = new AesUtility(key);
                encryptedString = aes.Encrypt(message, iv);
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
                encryptedString = BinaryToString(ul);

                AesUtility aes = new AesUtility(key);
                string decryptedString = aes.Decrypt(encryptedString, iv);

                output = AppDomain.CurrentDomain.BaseDirectory + "decrypt\\" + ofd.SafeFileName;
                FileStream fs = File.Create(output);
                fs.Close();
                File.WriteAllText(output, decryptedString);
                MessageBox.Show("The file has been crypted");
            }
        }

        //ZA SLIKE

        public static Bitmap ConvertByteToImage(byte[] bytes)
        {
            return (new Bitmap(Image.FromStream(new MemoryStream(bytes))));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string inputFileName = @"kl_tower.bmp";
            Encrypt(inputFileName, @"encrypt\\enc1.bmp");
            MessageBox.Show("ENCRYPTED BITMAP");
        }

        void Encrypt(string inFile, string outFile)
        {
            AesCryptoServiceProvider aesProvider = new AesCryptoServiceProvider();
            aesProvider.BlockSize = 128;
            aesProvider.KeySize = 256;
            aesProvider.Key = System.Text.Encoding.ASCII.GetBytes(strKey);
            aesProvider.IV = System.Text.Encoding.ASCII.GetBytes(strIV);
            aesProvider.Padding = PaddingMode.None;
            aesProvider.Mode = CipherMode.CBC;
            FileStream fileStream = new FileStream(inFile, FileMode.Open, FileAccess.Read);
            MemoryStream ms = new MemoryStream();
            fileStream.CopyTo(ms);
            var header = ms.ToArray().Take(54).ToArray();
            var imageArray = ms.ToArray().Skip(54).ToArray();
            fileStream.Close();
            var enc = aesProvider.CreateEncryptor();
            var encimg = new byte[24] { 0x01, 0x01, 0x10, 0x20, 0x03, 0x40, 0x50, 0x07, 0x04, 0x60, 0x50, 0x03, 0x01, 0x01, 0x06, 0x20, 0x11 , 0x33, 0x44,0x51 ,0x65 , 0x84, 0x56,0x33 };
            var image = Combine(header, encimg);
            File.WriteAllBytes(outFile, image);
            aesProvider.Clear();

            //https://www.codeguru.co.in/2013/09/how-to-encrypt-bitmap-image-in-c.html

        }

        private void btnDecryptBitmap_Click(object sender, EventArgs e)
        {
            Decrypt("d:\\enc1.bmp", "D:\\demo.bmp");
            MessageBox.Show("DECRYPTED BITMAP");
        }

        public byte[] Combine(byte[] first, byte[] second)
        {
            byte[] ret = new byte[first.Length + second.Length];
            Buffer.BlockCopy(first, 0, ret, 0, first.Length);
            Buffer.BlockCopy(second, 0, ret, first.Length, second.Length);
            return ret;
        }
        public void Decrypt(string inFile, string outFile)
        {
            AesCryptoServiceProvider aesProvider = new AesCryptoServiceProvider();
            aesProvider.BlockSize = 128;
            aesProvider.KeySize = 256;
            aesProvider.Padding = PaddingMode.None;
            aesProvider.Mode = CipherMode.CBC;
            aesProvider.Key = System.Text.Encoding.ASCII.GetBytes(strKey);
            aesProvider.IV = System.Text.Encoding.ASCII.GetBytes(strIV);

            FileStream fileStream = new FileStream(inFile, FileMode.Open, FileAccess.Read);
            MemoryStream ms = new MemoryStream();
            fileStream.CopyTo(ms);
            var header = ms.ToArray().Take(54).ToArray();
            var imageArray = ms.ToArray().Skip(54).ToArray();
            var enc = aesProvider.CreateDecryptor();
            var encimg = enc.TransformFinalBlock(imageArray, 0, imageArray.Length);
            var image = Combine(header, encimg);
            File.WriteAllBytes(outFile, image);
        }
    }
}
