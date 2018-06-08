using Ludus_Chip8.Cpu;
using Ludus_Chip8.Display;
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
        private readonly Chip8Display _display;
        private readonly RegisterBank _registerBank;

        public Chip8Cpu Cpu { get => this._cpu; }
        public Chip8Memory Memory { get => this._memory; }
        public RegisterBank RegisterBank { get => this._registerBank; }
        public Chip8Display Chip8Display { get => this._display; }

        public Chip8()
        {
            this._cpu = new Chip8Cpu(this);
            this._memory = new Chip8Memory(this);
            this._registerBank = new RegisterBank(this);
            this._display = new Chip8Display(this);
        }

        public void LoadRom(byte[] romBuffer)
        {
            // If a rom has already been loaded, we need to interrupt and reset the emulation loop here or else it could cause some problems.
            this._memory.LoadRom(romBuffer);
        }
    }
}
