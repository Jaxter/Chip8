using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ludus_Chip8.Cpu.Opcodes;

namespace Ludus_Chip8.Cpu.Instructions.Implementation
{
    /// <summary>
    /// Fx1E - ADD I, Vx
    /// Set I = I + Vx.
    /// </summary>
    public class AddInstruction3 : ICpuInstruction
    {
        public void Execute(Chip8 chip8Device, Opcode opcode)
        {
            chip8Device.RegisterBank.I += (chip8Device.RegisterBank.V[((opcode.Value & 0x0F00) >> 8)]);

            int i = 0;
        }
    }
}
