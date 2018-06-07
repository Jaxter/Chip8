using Ludus_Chip8.Cpu.Opcodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludus_Chip8.Cpu.Instructions
{
    public interface ICpuInstruction
    {
        void Execute(Chip8 chip8Device, Opcode opcode);
    }
}
