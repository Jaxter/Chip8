using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ludus_Chip8.Cpu.Opcodes;

namespace Ludus_Chip8.Cpu.Instructions.Implementation
{
    /// <summary>
    /// Annn - LD I, addr
    /// Set I = nnn.
    /// </summary>
    public class LdInstruction3 : ICpuInstruction
    {
        public void Execute(Chip8 chip8Device, Opcode opcode)
        {
            ushort address = (ushort)(opcode.Value & 0x0FFF);

            chip8Device.RegisterBank.I = address;
        }
    }
}
