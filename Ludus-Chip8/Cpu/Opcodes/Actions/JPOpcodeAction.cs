using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludus_Chip8.Cpu.Opcodes.Actions
{
    public class JPOpcodeAction : IOpcodeAction
    {
        private Chip8 _chip8Device;

        public Chip8 Chip8Device { set => this._chip8Device = value; }

        public void Execute(ushort opcode)
        {
            ushort address = (ushort)(opcode & 0x0FFF);

            this._chip8Device.RegisterBank.PC = address;
        }
    }
}
