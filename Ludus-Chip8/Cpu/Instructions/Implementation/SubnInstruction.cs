using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ludus_Chip8.Cpu.Opcodes;

namespace Ludus_Chip8.Cpu.Instructions.Implementation
{
    /// <summary>
    /// 8xy7 - SUBN Vx, Vy
    /// Set Vx = Vy - Vx, set VF = NOT borrow.
    /// </summary>
    public class SubnInstruction : ICpuInstruction
    {
        public void Execute(Chip8 chip8Device, Opcode opcode)
        {
            byte registerX = (byte)((opcode.Value & 0x0F00) >> 8);
            byte registerY = (byte)((opcode.Value & 0x00F0) >> 4);

            byte valueX = chip8Device.RegisterBank.V[registerX];
            byte valueY = chip8Device.RegisterBank.V[registerY];

            bool carry = (valueY > valueX);

            chip8Device.RegisterBank.V[0xF] = carry ? (byte)1 : (byte)0;

            chip8Device.RegisterBank.V[registerX] = (byte)(valueY - valueX);
        }
    }
}
