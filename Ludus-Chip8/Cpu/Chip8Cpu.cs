using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ludus_Chip8.Memory;
using Ludus_Chip8.Cpu.Opcodes;

namespace Ludus_Chip8
{
    public class Chip8Cpu
    {
        private Chip8 _chip8Device;
        private Stack<ushort> _stack;
        private OpcodeParser _opcodeParser;
        private bool _isRunning;

        public Stack<ushort> Stack { get { return this._stack; } }

        public Chip8Cpu(Chip8 chip8Device)
        {
            this._chip8Device = chip8Device;
            this._opcodeParser = new OpcodeParser(this._chip8Device);
            this._stack = new Stack<ushort>(Chip8Constants.STACK_SIZE);
            this._isRunning = false;
        }

        public void ProcessNextOpcode()
        {
            if (this._chip8Device.RegisterBank.V[0xF] == 1)
            {
                int y = 0;
            }

            ushort opcode = this.ReadNextOpcode();
            this._opcodeParser.ParseOpcode(opcode);


        }

        private ushort ReadNextOpcode()
        {
            if(this._chip8Device.RegisterBank.PC == 923)
            {
                int z = 0;
            }

            byte opcodePartOne = this._chip8Device.Memory.Get(this._chip8Device.RegisterBank.PC++);
            byte opcodePartTwo = this._chip8Device.Memory.Get((ushort)(this._chip8Device.RegisterBank.PC++));

            ushort opcode = (ushort)((opcodePartOne << 8) + opcodePartTwo);

            return opcode;
        }
    }
}
