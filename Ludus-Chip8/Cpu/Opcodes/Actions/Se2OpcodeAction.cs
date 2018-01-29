using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludus_Chip8.Cpu.Opcodes.Actions
{
    public class Se2OpcodeAction : IOpcodeAction
    {
        private Chip8 _chip8Device;

        public Chip8 Chip8Device { set => this._chip8Device = value; }

        public void Execute(ushort opcode)
        {
            byte registerX = (byte)(opcode & 0x0F00 >> 8);
            byte registerY = (byte)(opcode & 0x00F0);

            byte registerXValue = this._chip8Device.RegisterBank.V[registerX];
            byte registerYValue = this._chip8Device.RegisterBank.V[registerY];

            if (registerXValue == registerYValue)
                this._chip8Device.RegisterBank.PC += 2;
        }
    }
}
