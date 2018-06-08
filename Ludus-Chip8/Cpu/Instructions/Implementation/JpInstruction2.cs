using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ludus_Chip8.Cpu.Opcodes;

namespace Ludus_Chip8.Cpu.Instructions.Implementation
{
    /// <summary>
    /// Bnnn - JP V0, addr
    // Jump to location nnn + V0.
    /// </summary>
    public class JpInstruction2 : ICpuInstruction
    {
        public void Execute(Chip8 chip8Device, Opcode opcode)
        {
            ushort value = (ushort)(opcode.Value & 0x0FFF);

            ushort address = (ushort)(value + chip8Device.RegisterBank.V[0x0]);

            chip8Device.RegisterBank.PC = address;
        }
    }
}
