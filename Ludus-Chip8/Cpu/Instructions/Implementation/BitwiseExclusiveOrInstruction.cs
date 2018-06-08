﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ludus_Chip8.Cpu.Opcodes;

namespace Ludus_Chip8.Cpu.Instructions.Implementation
{
    /// <summary>
    /// 8xy3 - XOR Vx, Vy
    /// Set Vx = Vx XOR Vy.
    /// </summary>
    public class BitwiseExclusiveOrInstruction : ICpuInstruction
    {
        public void Execute(Chip8 chip8Device, Opcode opcode)
        {
            byte registerX = (byte)(opcode.Value & 0x0F00 >> 8);
            byte registerY = (byte)(opcode.Value & 0x00F0);

            byte valueX = chip8Device.RegisterBank.V[registerX];
            byte valueY = chip8Device.RegisterBank.V[registerY];

            byte newValue = (byte)(valueX ^ valueY);
        }
    }
}