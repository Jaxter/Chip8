using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ludus_Chip8.Cpu.Opcodes;

namespace Ludus_Chip8.Cpu.Instructions.Implementation
{
    /// <summary>
    /// Fx15 - LD DT, Vx
    /// Set delay timer = Vx.
    /// </summary>
    public class LdInstruction6 : ICpuInstruction
    {
        public void Execute(Chip8 chip8Device, Opcode opcode)
        {
            byte registerX = (byte)((opcode.Value & 0x0F00) >> 8);

            chip8Device.DelayTimer = chip8Device.RegisterBank.V[registerX];
        }
    }
}
