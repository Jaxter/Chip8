using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ludus_Chip8.Cpu.Opcodes;

namespace Ludus_Chip8.Cpu.Instructions.Implementation
{
    public class AddInstruction : ICpuInstruction
    {
        public void Execute(Chip8 chip8Device, Opcode opcode)
        {
            byte register = (byte)(opcode.Value & 0x0F00 >> 8);
            byte value = (byte)(opcode.Value & 0x00FF);

            chip8Device.RegisterBank.V[register] += value;
        }
    }
}
