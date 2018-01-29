using Ludus_Chip8.Cpu;
using Ludus_Chip8.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludus_Chip8
{
    public class Chip8
    {
        private readonly Chip8Cpu _cpu;
        private readonly Chip8Memory _memory;
        private readonly RegisterBank _registerBank;

        public Chip8Cpu Cpu { get { return this._cpu; } }
        public Chip8Memory Memory { get { return this._memory; } }
        public RegisterBank RegisterBank { get { return this._registerBank; } }

        public Chip8()
        {
            this._cpu = new Chip8Cpu(this);
            this._memory = new Chip8Memory(this);
            this._registerBank = new RegisterBank(this);
        }

        public void LoadRom(byte[] romBuffer)
        {
            // If a rom has already been loaded, we need to interrupt and reset the emulation loop here or else it could cause some problems.
            this._memory.LoadRom(romBuffer);
        }
    }
}
