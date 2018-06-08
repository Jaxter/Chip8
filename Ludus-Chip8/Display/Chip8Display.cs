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
        private Chip8 _device;

        public Chip8Display(Chip8 device)
        {
            this._device = device;
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
