using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludus_Chip8.Cpu.Opcodes
{
    public class Opcode
    {
        private ushort _identifier;
        private ushort value;

        public ushort Identifier { get { return this._identifier; } }
        public ushort Value { get { return this.value; } }

        public Opcode(ushort opcodeIdentifier, ushort opcode)
        {
            this._identifier = opcodeIdentifier;
            this.value = opcode;
        }
    }
}
