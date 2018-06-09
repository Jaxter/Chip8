using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ludus_Chip8.Cpu.Opcodes;

namespace Ludus_Chip8.Cpu.Instructions.Implementation
{
    /// <summary>
    /// Fx07 - LD Vx, DT
    //  Set Vx = delay timer value.
    /// </summary>
    public class LdInstruction4 : ICpuInstruction
    {
        public void Execute(Chip8 chip8Device, Opcode opcode)
        {
            byte registerX = (byte)((opcode.Value & 0x0F00) >> 8);

            chip8Device.RegisterBank.V[registerX] = chip8Device.DelayTimer;
        }
    }
}
