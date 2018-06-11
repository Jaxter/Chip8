using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ludus_Chip8.Cpu.Opcodes;

namespace Ludus_Chip8.Cpu.Instructions.Implementation
{
    /// <summary>
    /// 8xy4 - ADD Vx, Vy
    //  Set Vx = Vx + Vy, set VF = carry.
    /// </summary>
    public class AddInstruction2 : ICpuInstruction
    {
        public void Execute(Chip8 chip8Device, Opcode opcode)
        {
            byte registerX = (byte)((opcode.Value & 0x0F00) >> 8);
            byte registerY = (byte)((opcode.Value & 0x00F0) >> 4);

            byte valueX = chip8Device.RegisterBank.V[registerX];
            byte valueY = chip8Device.RegisterBank.V[registerY];

            byte newValue = (byte)(((ushort)(valueX + valueY)) & 0xFF);

            chip8Device.RegisterBank.V[0xF] = (newValue > 255) ? (byte)1 : (byte)0;
            chip8Device.RegisterBank.V[registerX] = newValue;
        }
    }
}
