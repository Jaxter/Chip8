using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ludus_Chip8.Cpu.Opcodes;

namespace Ludus_Chip8.Cpu.Instructions.Implementation
{
    /// <summary>
    /// Fx33 - LD B, Vx
    // Store BCD representation of Vx in memory locations I, I+1, and I+2.
    /// </summary>
    public class LdInstruction9 : ICpuInstruction
    {
        public void Execute(Chip8 chip8Device, Opcode opcode)
        {
            byte registerX = (byte)((opcode.Value & 0x0F00) >> 8);
            byte valueX = chip8Device.RegisterBank.V[registerX];

            ushort i = chip8Device.RegisterBank.I;

            chip8Device.Memory.Set((ushort)(i), (byte)(valueX / 100));
            chip8Device.Memory.Set((ushort)(i + 1), (byte)((valueX / 10) % 10));
            chip8Device.Memory.Set((ushort)(i + 2), (byte)((valueX % 100) % 10));
        }
    }
}
