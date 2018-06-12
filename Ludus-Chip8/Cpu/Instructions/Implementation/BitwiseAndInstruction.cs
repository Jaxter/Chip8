using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ludus_Chip8.Cpu.Opcodes;

namespace Ludus_Chip8.Cpu.Instructions.Implementation
{
    /// <summary>
    /// 8xy2 - AND Vx, Vy
    //  Set Vx = Vx AND Vy.
    /// </summary>
    public class BitwiseAndInstruction : ICpuInstruction
    {
        public void Execute(Chip8 chip8Device, Opcode opcode)
        {
            byte registerX = (byte)((opcode.Value & 0x0F00) >> 8);
            byte registerY = (byte)((opcode.Value & 0x00F0) >> 4);

            chip8Device.RegisterBank.V[registerX] &= chip8Device.RegisterBank.V[registerY];
        }
    }
}
