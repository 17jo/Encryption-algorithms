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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRC4_Click(object sender, EventArgs e)
        {
            RC4 rc = new RC4();
            rc.ShowDialog();
        }

        private void btnEnigma_Click(object sender, EventArgs e)
        {
            Enigma enig = new Enigma();
            enig.ShowDialog();
        }

        private void btnTEA_Click(object sender, EventArgs e)
        {
            TEA tea = new TEA();
            tea.ShowDialog();
        }

        private void btnCBC_Click(object sender, EventArgs e)
        {
            CBC cbc = new CBC();
            cbc.ShowDialog();
        }

        private void btnCRC_Click(object sender, EventArgs e)
        {
            CRC_c crc = new CRC_c();
            crc.ShowDialog();
        }
    }
}
