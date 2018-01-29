using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ludus_Chip8;

namespace Ludus_Chip8_Forms
{
    public partial class EmulatorForm : Form
    {
        public EmulatorForm()
        {
            InitializeComponent();
        }

        private void btnLoadRom_Click(object sender, EventArgs e)
        {
            Stream romStream = null;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                romStream = openFileDialog1.OpenFile();

                if (romStream != null)
                {
                    byte[] romFile = new byte[romStream.Length];

                    romStream.Read(romFile, 0, romFile.Length - 1);

                    Chip8Cpu cpu = new Chip8Cpu();

                    cpu.LoadRom(romFile);
                }
            }
        }
    }
}
