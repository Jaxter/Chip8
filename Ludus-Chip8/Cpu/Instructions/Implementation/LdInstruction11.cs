using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ludus_Chip8.Cpu.Opcodes;

namespace Ludus_Chip8.Cpu.Instructions.Implementation
{
    public class LdInstruction11 : ICpuInstruction
    {
        public void Execute(Chip8 chip8Device, Opcode opcode)
        {
            byte registerX = (byte)((opcode.Value & 0x0F00) >> 8);

            for (byte j = 0; j <= registerX; j++)
            {
                ushort i = (ushort)(chip8Device.RegisterBank.I + j);

                chip8Device.RegisterBank.V[j] = chip8Device.Memory.Get(i);
            }
        }
    }
}
