using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludus_Chip8.Cpu.Opcodes.Actions
{
    public interface IOpcodeAction
    {
        Chip8 Chip8Device { set; }
        void Execute(ushort opcode);
    }
}
