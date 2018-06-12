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
            byte registerX = (byte)((opcode.Value & 0x0F00) >> 8);
            byte valueX = chip8Device.RegisterBank.V[registerX];

            chip8Device.RegisterBank.V[0xF] = (byte)(valueX & 0x80);

            chip8Device.RegisterBank.V[registerX] = (byte)(valueX << 1);
        }
    }
}
