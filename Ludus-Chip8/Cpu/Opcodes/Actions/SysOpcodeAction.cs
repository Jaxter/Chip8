using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludus_Chip8.Cpu.Opcodes.Actions
{
    public class SysOpcodeAction : IOpcodeAction
    {
        private Chip8 _chip8Device;

        public Chip8 Chip8Device { set => this._chip8Device = value; }

        public void Execute(ushort opcode)
        {
            ushort type = (ushort)(opcode & 0x00FF);

            switch (type)
            {
                case 0x00E0:
                    CLS();
                    break;

                case 0x00EE:
                    RET();
                    break;
            }
        }

        private void CLS()
        {
            // clears the display
        }

        private void RET()
        {
            this._chip8Device.RegisterBank.PC = this._chip8Device.Cpu.Stack.Pop();
        }
    }
}
