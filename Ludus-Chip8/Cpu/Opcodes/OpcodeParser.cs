using Ludus_Chip8.Cpu.Opcodes.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludus_Chip8.Cpu.Opcodes
{
    public class OpcodeParser
    {
        private Chip8 _chip8Device;

        public OpcodeParser(Chip8 chip8Device)
        {
            this._chip8Device = chip8Device;
        }

        public Opcode ParseOpcode(ushort opcode)
        {

        }
    }
}
