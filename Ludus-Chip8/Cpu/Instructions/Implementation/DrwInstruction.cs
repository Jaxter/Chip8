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

            byte x = chip8Device.RegisterBank.V[registerX];
            byte y = chip8Device.RegisterBank.V[registerY];

            byte n = (byte)(opcode.Value & 0x000F);

            chip8Device.RegisterBank.V[0xF] = 0;

            for(int height = 0; height < n; height++)
            {
                byte spriteData = chip8Device.Memory.Get((ushort)(chip8Device.RegisterBank.I + height));

                for(int width = 0; width < 8; width++)
                {
                    if((spriteData & (0x80 >> width)) != 0)
                    {
                        ushort drawX = (ushort)((x + width) % 64);
                        ushort drawY = (ushort)((y + height) % 32);

                        if(chip8Device.Chip8Display.Display[drawX, drawY])
                        {
                            chip8Device.RegisterBank.V[0xF] = 1;
                        }

                        chip8Device.Chip8Display.Display[drawX, drawY] ^= true;
                    }
                }
            }

            chip8Device.Chip8Display.UpdateDisplay();
        }
    }
}
