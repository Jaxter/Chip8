using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludus_Chip8.Memory
{
    public class Chip8Memory
    {
        private Chip8 _chip8Device;
        private byte[] _memory;

        public Chip8Memory(Chip8 chip8Device)
        {
            this._chip8Device = chip8Device;
            this._memory = new byte[Chip8Constants.MEMORY_SIZE];

            this.InitialiseFontset();
        }

        public byte Get(ushort address)
        {
            return this._memory[address];
        }

        public void Set(ushort address, byte value)
        {
            this._memory[address] = value;
        }

        public void LoadRom(byte[] romBuffer)
        {
            romBuffer.CopyTo(this._memory, Chip8Constants.MEMORY_START_ADDRESS);
        }

        private void InitialiseFontset()
        {
            Chip8Constants.FONTSET.CopyTo(this._memory, 0);
        }
    }
}
