using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ludus_Chip8.Cpu.Opcodes;

namespace Ludus_Chip8.Cpu.Instructions.Implementation
{
    /// <summary>
    /// Dxyn - DRW Vx, Vy, nibble
    /// Display n-byte sprite starting at memory location I at(Vx, Vy), set VF = collision.
    /// </summary>
    public class DrwInstruction : ICpuInstruction
    {
        public void Execute(Chip8 chip8Device, Opcode opcode)
        {
            byte registerX = (byte)((opcode.Value & 0x0F00) >> 8);
            byte registerY = (byte)((opcode.Value & 0x00F0) >> 4);

            byte posX = chip8Device.RegisterBank.V[registerX];
            byte posY = chip8Device.RegisterBank.V[registerY];

            byte spriteLength = (byte)(opcode.Value & 0x000F);

            for(int y = 0; y < spriteLength; y++)
            {
                byte lineData = chip8Device.Memory.Get((ushort)(chip8Device.RegisterBank.I + y));

                for(int x = 0; x < 8; x++)
                {
                    if((lineData & (0x80 >> x)) != 0)
                    {
                        int position = posX + (posY * 64);
                        bool positionBitSet = chip8Device.Chip8Display.Get(position);

                        chip8Device.RegisterBank.V[0xF] = positionBitSet ? (byte)1 : (byte)0;

                        chip8Device.Chip8Display.SetPixelState(position, positionBitSet ^ true);

                        if (positionBitSet)
                        {
                            int i = 0;
                        } else
                        {
                            int i = 0;
                        }
                    }
                }
            }

            chip8Device.Chip8Display.UpdateDisplay();
        }
    }
}
