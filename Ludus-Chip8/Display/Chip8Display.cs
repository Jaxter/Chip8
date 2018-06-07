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
        private BitArray _display;

        public Chip8Display()
        {
            this._display = new BitArray(Chip8Constants.SCREEN_SIZE);
        }

        public void SetPixelState(int position, bool state)
        {
            this._display[position] = state;
        }

        public void Reset()
        {
            this._display.SetAll(false);
        }
    }
}
