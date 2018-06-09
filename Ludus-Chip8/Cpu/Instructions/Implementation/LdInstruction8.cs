using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ludus_Chip8.Cpu.Opcodes;

namespace Ludus_Chip8.Cpu.Instructions.Implementation
{
    /// <summary>
    /// Fx29 - LD F, Vx
    // Set I = location of sprite for digit Vx.
    /// </summary>
    public class LdInstruction8 : ICpuInstruction
    {
        public void Execute(Chip8 chip8Device, Opcode opcode)
        {
            byte registerX = (byte)((opcode.Value & 0x0F00) >> 8);

            chip8Device.RegisterBank.I = chip8Device.RegisterBank.V[registerX];
        }
    }
}
