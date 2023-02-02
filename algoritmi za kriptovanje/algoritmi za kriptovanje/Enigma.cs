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
    public partial class Enigma : Form
    {
        private static string _alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static string _key = "QWERTYUIOPASDFGHJKLZXCVBNM";
        private static string _reflector = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        private string output;
        public Enigma()
        {
            InitializeComponent();
        }

        private void Enigma_Load(object sender, EventArgs e)
        {

        }

        public static string Encrypt(string plaintext)
        {
            var builder = new StringBuilder();

            foreach (char c in plaintext)
            {
                int index = _alphabet.IndexOf(c);
                builder.Append(_key[index]);
            }

            var output = builder.ToString();
            builder.Clear();
            foreach (char c in output)
            {
                int index = _alphabet.IndexOf(c);
                builder.Append(_reflector[index]);
            }

            return builder.ToString();
        }

        public static string Decrypt(string ciphertext)
        {
            var builder = new StringBuilder();

            var input = ciphertext;
            foreach (char c in input)
            {
                int index = _reflector.IndexOf(c);
                builder.Append(_alphabet[index]);
            }

            input = builder.ToString();
            builder.Clear();
            foreach (char c in input)
            {
                int index = _key.IndexOf(c);
                builder.Append(_alphabet[index]);
            }

            return builder.ToString();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            string massage = textBox1.Text;
            string massage2 = massage.ToUpper();
            string encryptmessage = Encrypt(massage2);
            textBox2.Text = encryptmessage;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string massage = textBox2.Text;
            string decryptmessage = Decrypt(massage);
            textBox2.Text = decryptmessage;
        }
    }
}
