using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludus_Chip8.Cpu.Opcodes.Actions
{
    public class CallOpcodeAction : IOpcodeAction
    {
        private Chip8 _chip8Device;

        public Chip8 Chip8Device { set => this._chip8Device = value; }

        public void Execute(ushort opcode)
        {
            ushort currentAddress = this._chip8Device.RegisterBank.PC;
            ushort callAddress = (ushort)(opcode & 0x0FFF);

            this._chip8Device.Cpu.Stack.Push(currentAddress);
            this._chip8Device.RegisterBank.PC = callAddress;
        }
    }
}
