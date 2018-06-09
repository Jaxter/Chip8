using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ludus_Chip8.Cpu.Opcodes;

namespace Ludus_Chip8.Cpu.Instructions.Implementation
{
    /// <summary>
    /// Cxkk - RND Vx, byte
    /// Set Vx = random byte AND kk
    /// </summary>
    public class RndInstruction : ICpuInstruction
    {
        public void Execute(Chip8 chip8Device, Opcode opcode)
        {
            byte registerX = (byte)((opcode.Value & 0x0F00) >> 8);
            byte kk = (byte)(opcode.Value & 0x00FF);

            byte randomByte = (byte)new Random().Next(0, 255);

            chip8Device.RegisterBank.V[registerX] = (byte)(randomByte & kk);
        }
    }
}
