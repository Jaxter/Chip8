using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludus_Chip8.Input
{
    public class InputManager
    {
        private BitArray _keys;
        private bool _keyPressed;
        private byte _keyPressedValue;

        public bool KeyPressed { get => _keyPressed; }
        public byte KeyPressedValue { get => _keyPressedValue; }

        public InputManager()
        {
            this._keys = new BitArray(Chip8Constants.KEYS);
            this._keyPressedValue = 0;
            this._keyPressed = false;
        }

        public bool GetKeyState(int key)
        {
            return this._keys.Get(key);
        }

        public void SetKey(int key, bool value)
        {
            this._keys.Set(key, value);
        }

        public void ResetKeyPressed()
        {
            this._keyPressed = false;
            this._keyPressedValue = 0;
        }
    }
}
