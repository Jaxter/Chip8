using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ludus_Chip8.Cpu.Opcodes;

namespace Ludus_Chip8.Cpu.Instructions.Implementation
{
    public class ShlInstruction : ICpuInstruction
    {
        public void Execute(Chip8 chip8Device, Opcode opcode)
        {
            byte registerX = (byte)(opcode.Value & 0x0F00 >> 8);
            byte valueX = chip8Device.RegisterBank.V[registerX];

            bool carry = ((valueX >> 8) & 1) != 0;

            chip8Device.RegisterBank.V[0xF] = carry ? (byte)1 : (byte)0;

            chip8Device.RegisterBank.V[registerX] *= 2;
        }
    }
}
