using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ludus_Chip8.Cpu.Opcodes;

namespace Ludus_Chip8.Cpu.Instructions
{
    /// <summary>
    /// 9xy0 - SNE Vx, Vy
    /// Skip next instruction if Vx != Vy.
    /// </summary>
    public class SneInstruction2 : ICpuInstruction
    {
        public void Execute(Chip8 chip8Device, Opcode opcode)
        {
            byte registerX = (byte)(opcode.Value & 0x0F00 >> 8);
            byte registerY = (byte)(opcode.Value & 0x00F0 >> 4);

            byte valueX = chip8Device.RegisterBank.V[registerX];
            byte valueY = chip8Device.RegisterBank.V[registerY];

            if (valueX != valueY)
                chip8Device.RegisterBank.PC += 2;
        }
    }
}
