using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ludus_Chip8.Cpu.Opcodes;

namespace Ludus_Chip8.Cpu.Instructions.Implementation
{
    /// <summary>
    /// 4xkk - SNE Vx, byte
    /// Skip next instruction if Vx != kk.
    /// </summary>
    public class SneInstruction : ICpuInstruction
    {
        public void Execute(Chip8 chip8Device, Opcode opcode)
        {
            byte registerX = (byte)(opcode.Value & 0x0F00 >> 8);
            byte valueToCompare = (byte)(opcode.Value & 0x00FF);

            byte registerXValue = chip8Device.RegisterBank.V[registerX];

            if (registerXValue != valueToCompare)
                chip8Device.RegisterBank.PC += 2;
        }
    }
}
