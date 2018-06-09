using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ludus_Chip8.Cpu.Opcodes;

namespace Ludus_Chip8.Cpu.Instructions.Implementation
{
    public class CallInstruction : ICpuInstruction
    {
        public void Execute(Chip8 chip8Device, Opcode opcode)
        {
            ushort callAddress = (ushort)(opcode.Value & 0xFFF);

            chip8Device.Cpu.Stack.Push(chip8Device.RegisterBank.PC);
            chip8Device.RegisterBank.PC = callAddress;
        }
    }
}
