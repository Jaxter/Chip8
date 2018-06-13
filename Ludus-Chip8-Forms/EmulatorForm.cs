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
        private Bitmap _bitmap;
        private Graphics _graphicsDisplay;
        private int _xMultiplier;
        private int _yMultiplier;

        public EmulatorForm()
        {
            InitializeComponent();

            this._chip8 = new Chip8();
            this._chip8.Chip8Display.SetUpdateGraphicsAction(this.UpdateDisplay);
            this._xMultiplier = (gameCanvas.ClientRectangle.Width / Chip8Constants.SCREEN_WIDTH);
            this._yMultiplier = (gameCanvas.ClientRectangle.Height / Chip8Constants.SCREEN_HEIGHT);


            this._bitmap = new Bitmap(gameCanvas.ClientRectangle.Width, gameCanvas.ClientRectangle.Height);
            this._graphicsDisplay = Graphics.FromImage(this._bitmap);

            gameCanvas.Image = this._bitmap;

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

        private void UpdateDisplay(bool[,] bitArray)
        {
            this.Invoke((MethodInvoker)delegate
            {
                this.UpdateGameCanvas(bitArray);
            });
        }

        private void UpdateGameCanvas(bool[,] bitArray)
        {
            this._graphicsDisplay.Clear(Color.Black);

            for (int y = 0; y < Chip8Constants.SCREEN_HEIGHT; y++)
            {
                for (int x = 0; x < Chip8Constants.SCREEN_WIDTH; x++)
                {
                    bool positionSet = bitArray[x, y];
                    Color pixelColour = positionSet ? Color.White : Color.Black;

                    this._graphicsDisplay.FillRectangle(new SolidBrush(pixelColour), (x * this._xMultiplier), (y * this._yMultiplier),
                        this._xMultiplier, this._yMultiplier);
                }
            }

            gameCanvas.Image = this._bitmap;
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

                    timer1.Enabled = true;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 50; i++)
            {
                _chip8.Cycle();
            }

            _chip8.Tick();
            _chip8.Chip8Display.UpdateDisplay();
        }
    }
}
