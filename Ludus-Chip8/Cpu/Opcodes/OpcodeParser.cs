using Ludus_Chip8.Cpu.Opcodes.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludus_Chip8.Cpu.Opcodes
{
    public class OpcodeParser
    {
        private Dictionary<byte, IOpcodeAction> _opcodeActionsDictionary;
        private Chip8 _chip8Device;

        public OpcodeParser(Chip8 chip8Device)
        {
            this._chip8Device = chip8Device;
            this._opcodeActionsDictionary = new Dictionary<byte, IOpcodeAction>();

            (this._opcodeActionsDictionary[0x0] = new SysOpcodeAction()).Chip8Device = chip8Device;
            (this._opcodeActionsDictionary[0x1] = new JPOpcodeAction()).Chip8Device = chip8Device;
            (this._opcodeActionsDictionary[0x2] = new CallOpcodeAction()).Chip8Device = chip8Device;
            (this._opcodeActionsDictionary[0x3] = new SeOpcodeAction()).Chip8Device = chip8Device;
            (this._opcodeActionsDictionary[0x4] = new SneOpcodeAction()).Chip8Device = chip8Device;
            (this._opcodeActionsDictionary[0x5] = new Se2OpcodeAction()).Chip8Device = chip8Device;
            (this._opcodeActionsDictionary[0x6] = new LdOpcodeAction()).Chip8Device = chip8Device;
        }

        public Opcode ParseOpcode(ushort opcode)
        {
            byte opcodeIdentifier = (byte)(opcode & 0xF000 >> 8);
            IOpcodeAction opcodeAction;

            if(this._opcodeActionsDictionary.TryGetValue(opcodeIdentifier, out opcodeAction))
            {
                return new Opcode(opcodeIdentifier, opcode, opcodeAction);
            }

            throw new Exception(String.Format("Failed to find opcode action for instruction {0:x4}", opcode.ToString()));
        }
    }
}
