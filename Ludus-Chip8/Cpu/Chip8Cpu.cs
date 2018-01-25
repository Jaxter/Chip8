using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ludus_Chip8.Memory;

namespace Ludus_Chip8
{
    public class Chip8Cpu
    {
        private Chip8 _chip8Device;
        private Stack<ushort> _stack;
        private ushort _pc;
        private ushort _i;
        private bool _isRunning;

        public ushort PC { get { return this._pc; } set { this._pc = value; } }
        public ushort I { get { return this._i; } set { this._i = value; } }

        public Stack<ushort> Stack { get { return this._stack; } }

        public Chip8Cpu(Chip8 chip8Device)
        {
            this._chip8Device = chip8Device;
            this._stack = new Stack<ushort>();
            this._isRunning = false;
        }

        public void Initialise()
        {
            this._pc = Chip8Constants.MEMORY_START_ADDRESS;
            this._i = 0;
        }

        public void Cycle()
        {
            while (this._isRunning)
            {
                
            }
        }
    }
}
