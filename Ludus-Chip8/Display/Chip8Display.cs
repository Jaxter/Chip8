using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludus_Chip8.Display
{
    public class Chip8Display
    {
        private readonly bool[,] _display;
        private Chip8 _device;
        private Action<bool[,]> _updateGraphicsAction;
        private bool _drawFlag = false;

        public bool[,] Display { get { return this._display; } }
        public bool DrawFlag { get => this._drawFlag; set => this._drawFlag = value; }

        public Chip8Display(Chip8 device)
        {
            this._device = device;
            this._display = new bool[64, 32];
        }

        public void SetUpdateGraphicsAction(Action<bool[,]> action)
        {
            this._updateGraphicsAction = action;
        }

        public void UpdateDisplay()
        {
            if(this._drawFlag)
            this._updateGraphicsAction.Invoke(this._display);
        }

        public void Reset()
        {
            for(int x = 0; x < 64; x++)
            {
                for (int y = 0; y < 32; y++){
                    this._display[x, y] = false;
                }
            }
        }
    }
}
