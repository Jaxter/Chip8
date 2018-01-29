using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludus_Chip8.Cpu.Opcodes.Actions
{
    public class SeOpcodeAction : IOpcodeAction
    {
        private Chip8 _chip8Device;

        public Chip8 Chip8Device { set => this._chip8Device = value; }

        public void Execute(ushort opcode)
        {
            byte registerX = (byte)(opcode & 0x0F00 >> 8);
            byte valueToCompare = (byte)(opcode & 0x00FF);

            byte registerXValue = this._chip8Device.RegisterBank.V[registerX];

            if (registerXValue == valueToCompare)
                this._chip8Device.RegisterBank.PC += 2;
        }
    }
}
