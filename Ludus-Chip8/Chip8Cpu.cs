using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludus_Chip8
{
    public class Chip8Cpu
    {
        private byte[] _memory;
        private ushort _pc;
        private ushort _i;
        private bool _isRunning;
        private byte[] _fontSet =
        {
              0xF0, 0x90, 0x90, 0x90, 0xF0, // 0
              0x20, 0x60, 0x20, 0x20, 0x70, // 1
              0xF0, 0x10, 0xF0, 0x80, 0xF0, // 2
              0xF0, 0x10, 0xF0, 0x10, 0xF0, // 3
              0x90, 0x90, 0xF0, 0x10, 0x10, // 4
              0xF0, 0x80, 0xF0, 0x10, 0xF0, // 5
              0xF0, 0x80, 0xF0, 0x90, 0xF0, // 6
              0xF0, 0x10, 0x20, 0x40, 0x40, // 7
              0xF0, 0x90, 0xF0, 0x90, 0xF0, // 8
              0xF0, 0x90, 0xF0, 0x10, 0xF0, // 9
              0xF0, 0x90, 0xF0, 0x90, 0x90, // A
              0xE0, 0x90, 0xE0, 0x90, 0xE0, // B
              0xF0, 0x80, 0x80, 0x80, 0xF0, // C
              0xE0, 0x90, 0x90, 0x90, 0xE0, // D
              0xF0, 0x80, 0xF0, 0x80, 0xF0, // E
              0xF0, 0x80, 0xF0, 0x80, 0x80  // F
        };

        public ushort PC { get { return this._pc; } set { this._pc = value; } }
        public ushort I { get { return this._i; } set { this._i = value; } }

        public Chip8Cpu()
        {
            this._memory = new byte[0xFFF];
            this._isRunning = false;
        }

        public void Initialise()
        {
            this._pc = 0x200;
            this._i = 0;
        }

        public void LoadRom(Stream romStream)
        {
            romStream.Read(this._memory, 0x200, (int)romStream.Length);
        }

        public void EmulateCpuLoop()
        {
            while (this._isRunning)
            {

            }
        }

        private void LoadFontset()
        {
            for(int i = 0; i < this._fontSet.Length; i++)
            {
                this._memory[i] = this._fontSet[i];
            }
        }
    }
}
