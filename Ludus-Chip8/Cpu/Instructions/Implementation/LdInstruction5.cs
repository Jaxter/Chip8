using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ludus_Chip8.Cpu.Opcodes;

namespace Ludus_Chip8.Cpu.Instructions.Implementation
{
    /// <summary>
    /// Fx0A - LD Vx, K
    /// Wait for a key press, store the value of the key in Vx.
    /// </summary>
    public class LdInstruction5 : ICpuInstruction
    {
        public void Execute(Chip8 chip8Device, Opcode opcode)
        {
            byte registerX = (byte)((opcode.Value & 0x0F00) >> 8);

            while (!chip8Device.InputManager.KeyPressed) {}

            chip8Device.RegisterBank.V[registerX] = (byte)chip8Device.InputManager.KeyPressedValue;

            chip8Device.InputManager.ResetKeyPressed();
        }
    }
}
