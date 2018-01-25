using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludus_Chip8.Cpu.Opcodes
{
    public class OpcodeParser
    {
        public Opcode ParseOpcode(ushort opcode)
        {
            ushort opcodeIdentifier = (ushort)(opcode & 0xF000);

            return null;
        }
    }
}
