using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ludus_Chip8;

namespace Ludus_Chip8_Forms
{
    public partial class EmulatorForm : Form
    {
        private Chip8 _chip8;

        public EmulatorForm()
        {
            InitializeComponent();

            this._chip8 = new Chip8();
            this._chip8.Chip8Display.SetUpdateGraphicsAction(this.UpdateDisplay);

            Bitmap test = new Bitmap(gameCanvas.ClientRectangle.Width, gameCanvas.ClientRectangle.Height);
            using (Graphics graphics = Graphics.FromImage(test))
            {
                graphics.Clear(Color.Black);
            }

            this.KeyDown += EmulatorForm_KeyDown;
            this.KeyUp += EmulatorForm_KeyUp;
        }

        private void EmulatorForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D1)
                this._chip8.InputManager.SetKey(1, false);
            if (e.KeyCode == Keys.D2)
                this._chip8.InputManager.SetKey(2, false);
            if (e.KeyCode == Keys.D3)
                this._chip8.InputManager.SetKey(3, false);
            if (e.KeyCode == Keys.D4)
                this._chip8.InputManager.SetKey(0xC, false);
            if (e.KeyCode == Keys.Q)
                this._chip8.InputManager.SetKey(4, false);
            if (e.KeyCode == Keys.W)
                this._chip8.InputManager.SetKey(5, false);
            if (e.KeyCode == Keys.E)
                this._chip8.InputManager.SetKey(6, false);
            if (e.KeyCode == Keys.R)
                this._chip8.InputManager.SetKey(0xD, false);
            if (e.KeyCode == Keys.A)
                this._chip8.InputManager.SetKey(7, false);
            if (e.KeyCode == Keys.S)
                this._chip8.InputManager.SetKey(8, false);
            if (e.KeyCode == Keys.D)
                this._chip8.InputManager.SetKey(9, false);
            if (e.KeyCode == Keys.F)
                this._chip8.InputManager.SetKey(0xE, false);
            if (e.KeyCode == Keys.Z)
                this._chip8.InputManager.SetKey(0xA, false);
            if (e.KeyCode == Keys.X)
                this._chip8.InputManager.SetKey(0, false);
            if (e.KeyCode == Keys.C)
                this._chip8.InputManager.SetKey(0xB, false);
            if (e.KeyCode == Keys.V)
                this._chip8.InputManager.SetKey(0xF, false);
        }

        private void EmulatorForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D1)
                this._chip8.InputManager.SetKey(1, true);
            if (e.KeyCode == Keys.D2)
                this._chip8.InputManager.SetKey(2, true);
            if (e.KeyCode == Keys.D3)
                this._chip8.InputManager.SetKey(3, true);
            if (e.KeyCode == Keys.D4)
                this._chip8.InputManager.SetKey(0xC, true);
            if (e.KeyCode == Keys.Q)
                this._chip8.InputManager.SetKey(4, true);
            if (e.KeyCode == Keys.W)
                this._chip8.InputManager.SetKey(5, true);
            if (e.KeyCode == Keys.E)
                this._chip8.InputManager.SetKey(6, true);
            if (e.KeyCode == Keys.R)
                this._chip8.InputManager.SetKey(0xD, true);
            if (e.KeyCode == Keys.A)
                this._chip8.InputManager.SetKey(7, true);
            if (e.KeyCode == Keys.S)
                this._chip8.InputManager.SetKey(8, true);
            if (e.KeyCode == Keys.D)
                this._chip8.InputManager.SetKey(9, true);
            if (e.KeyCode == Keys.F)
                this._chip8.InputManager.SetKey(0xE, true);
            if (e.KeyCode == Keys.Z)
                this._chip8.InputManager.SetKey(0xA, true);
            if (e.KeyCode == Keys.X)
                this._chip8.InputManager.SetKey(0, true);
            if (e.KeyCode == Keys.C)
                this._chip8.InputManager.SetKey(0xB, true);
            if (e.KeyCode == Keys.V)
                this._chip8.InputManager.SetKey(0xF, true);

            if (e.KeyCode == Keys.Escape)
                this._chip8.Exit = true;

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

                }
            }
        }

        private void UpdateDisplay(BitArray bitArray)
        {
            this.Invoke((MethodInvoker)delegate
            {
                this.UpdateGameCanvas(bitArray);
            });
        }

        private void UpdateGameCanvas(BitArray bitArray)
        {
            byte[] bytes = new byte[((bitArray.Length - 1) / 8) + 1];
            bitArray.CopyTo(bytes, 0);

            Image image;

            using (MemoryStream memoryStream = new MemoryStream(bytes))
            {
                image = Bitmap.FromStream(memoryStream);
            }

            this.gameCanvas.Image = image;
        }

        private void openRom_Click(object sender, EventArgs e)
        {
            Stream romStream = null;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                romStream = openFileDialog1.OpenFile();
                byte[] romFile;

                if (romStream != null)
                {
                    romFile = new byte[romStream.Length];

                    romStream.Read(romFile, 0, romFile.Length - 1);

                    this._chip8.LoadRom(romFile);

                    new Thread(() => this._chip8.Start()).Start();
                }
            }
        }
    }
}
