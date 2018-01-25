using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludus_Chip8.Cpu.Instructions
{
    public class DecodedInstruction
    {
        private ushort _instruction;

        public ushort Instruction { get { return this._instruction; } }

        public void Execute()
        {
            // Do whatever we need to do to satisfy the opcode here.
        }
    }
}
