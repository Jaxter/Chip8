using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludus_Chip8.Cpu.Opcodes
{
    public class OpcodeParser
    {
        private Chip8 _chip8Device;
        private InstructionResolver _instructionResolver;

        public OpcodeParser(Chip8 chip8Device)
        {
            this._chip8Device = chip8Device;
            this._instructionResolver = new InstructionResolver();
        }

        public void ParseOpcode(ushort opcodeValue)
        {
            byte opcodeIdentifier = (byte)((opcodeValue & 0xF000) >> 12);

            Opcode opcode = new Opcode(opcodeIdentifier, opcodeValue);

            if (opcode.Value == 41949)
            {
                int i = 0;
            }
                

            this._instructionResolver.ResolveOpcode(opcode.Value).Execute(this._chip8Device, opcode);
        }
    }
}
