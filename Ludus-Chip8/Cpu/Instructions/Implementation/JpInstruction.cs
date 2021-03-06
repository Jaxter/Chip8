﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ludus_Chip8.Cpu.Opcodes;

namespace Ludus_Chip8.Cpu.Instructions.Implementation
{
    public class JpInstruction : ICpuInstruction
    {
        public void Execute(Chip8 chip8Device, Opcode opcode)
        {
            ushort address = (ushort)(opcode.Value & 0x0FFF);

            chip8Device.RegisterBank.PC = address;
        }
    }
}
