using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ludus_Chip8.Cpu.Opcodes;

namespace Ludus_Chip8.Cpu.Instructions.Implementation
{
    /// <summary>
    /// Fx18 - LD ST, Vx
    //  Set sound timer = Vx.
    /// </summary>
    public class LdInstruction7 : ICpuInstruction
    {
        public void Execute(Chip8 chip8Device, Opcode opcode)
        {
            byte registerX = (byte)((opcode.Value & 0x0F00) >> 8);

            chip8Device.SoundTimer = chip8Device.RegisterBank.V[registerX];
        }
    }
}
