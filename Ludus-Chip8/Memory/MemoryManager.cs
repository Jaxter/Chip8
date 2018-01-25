using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludus_Chip8.Memory
{
    public class MemoryManager
    {
        private byte[] _memoryBuffer;

        public MemoryManager()
        {
            this._memoryBuffer = new byte[Chip8Constants.MEMORY_SIZE];

            this.InitialiseFontset();
        }

        public byte Get(ushort address)
        {
            return this._memoryBuffer[address];
        }

        public void LoadRom(byte[] romBuffer)
        {
            romBuffer.CopyTo(_memoryBuffer, Chip8Constants.MEMORY_START_ADDRESS);
        }

        private void InitialiseFontset()
        {
            Chip8Constants.FONTSET.CopyTo(this._memoryBuffer, 0);
        }
    }
}
