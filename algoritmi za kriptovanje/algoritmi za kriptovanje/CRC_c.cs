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

namespace _17969_Jovana_Stepanovic
{
    public partial class CRC_c : Form
    {
        public CRC_c()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                byte[] file2Hash = ComputeChecksum(openFileDialog1.FileName);
                textBox1.Text = System.Text.Encoding.UTF8.GetString(file2Hash);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                byte[] file2Hash = ComputeChecksum(openFileDialog2.FileName);
                textBox2.Text = System.Text.Encoding.UTF8.GetString(file2Hash);
            }
        }

        public static byte[] ComputeChecksum(string filePath)
        {
            using (FileStream stream = File.OpenRead(filePath))
            {
                var crc32 = new CRC32();
                return crc32.ComputeHash(stream);
            }
        }

        public static bool CheckFile(string filePath, byte[] expectedChecksum)
        {
            byte[] actualChecksum = ComputeChecksum(filePath);
            return BitConverter.ToInt32(expectedChecksum, 0) == BitConverter.ToInt32(actualChecksum, 0);
        }

        class CRC32 : HashAlgorithm
        {
            private static readonly uint[] _table = CreateTable();
            private uint _checksum;

            public CRC32()
            {
                HashSizeValue = 32;
                Initialize();
            }

            public override void Initialize()
            {
                _checksum = 0xffffffff;
            }

            protected override void HashCore(byte[] array, int ibStart, int cbSize)
            {
                _checksum = (uint)((_checksum >> 8) ^ _table[(array[ibStart] ^ _checksum) & 0xff]);

                for (int i = ibStart + 1; i < ibStart + cbSize; i++)
                {
                    _checksum = (uint)((_checksum >> 8) ^ _table[(array[i] ^ _checksum) & 0xff]);
                }
            }

            protected override byte[] HashFinal()
            {
                return BitConverter.GetBytes(~_checksum);
            }

            private static uint[] CreateTable()
            {
                uint[] table = new uint[256];

                for (uint i = 0; i < 256; i++)
                {
                    uint c = i;

                    for (int j = 0; j < 8; j++)
                    {
                        if ((c & 1) != 0)
                        {
                            c = (uint)((c >> 1) ^ 0xedb88320);
                        }
                        else
                        {
                            c >>= 1;
                        }
                    }

                    table[i] = c;
                }

                return table;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == textBox2.Text) MessageBox.Show("The files are equal");
            else MessageBox.Show("The files are not equal");
        }
    }
}
