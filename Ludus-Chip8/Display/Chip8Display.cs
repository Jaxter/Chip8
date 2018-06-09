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
        private Action<BitArray> _updateGraphicsAction;

        public Chip8Display(Chip8 device)
        {
            this._device = device;
            this._display = new BitArray(Chip8Constants.SCREEN_SIZE);
        }

        public bool Get(int position)
        {
            return this._display.Get(position);
        }

        public void SetPixelState(int position, bool state)
        {
            this._display.Set(position, state);
        }

        public void SetUpdateGraphicsAction(Action<BitArray> action)
        {
            this._updateGraphicsAction = action;
        }

        public void UpdateDisplay()
        {
            this._updateGraphicsAction.Invoke(this._display);
        }

        public void Reset()
        {
            this._display.SetAll(false);
        }
    }
}
