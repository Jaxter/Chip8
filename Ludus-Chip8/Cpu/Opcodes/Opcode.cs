using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludus_Chip8.Cpu.Opcodes
{
    public class Opcode
    {
        private ushort _opcodeIdentifier;
        private ushort _opcode;

        public ushort OpcodeIdentifier { get { return this._opcodeIdentifier; } }
        public ushort OpcodeValue { get { return this._opcode; } }

        public Opcode(ushort opcodeIdentifier, ushort opcode)
        {
            this._opcodeIdentifier = opcodeIdentifier;
            this._opcode = opcode;
        }
    }
}
