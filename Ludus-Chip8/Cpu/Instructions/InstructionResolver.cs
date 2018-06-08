using Ludus_Chip8.Cpu.Instructions;
using Ludus_Chip8.Cpu.Instructions.Implementation;
using System;
using System.Collections.Generic;

namespace Ludus_Chip8.Cpu.Opcodes
{
    public class InstructionResolver
    {
        private Dictionary<byte, Func<ushort, ICpuInstruction>> _cpuInstructionResolvers;

        public InstructionResolver()
        {
            this._cpuInstructionResolvers = new Dictionary<byte, Func<ushort, ICpuInstruction>>();

            this._cpuInstructionResolvers[0x0] = InstructionResolverHelpers.Resolve0x0;
            this._cpuInstructionResolvers[0x1] = ((i) => new JpInstruction());
            this._cpuInstructionResolvers[0x2] = ((i) => new CallInstruction());
            this._cpuInstructionResolvers[0x3] = ((i) => new SeInstruction());
            this._cpuInstructionResolvers[0x4] = ((i) => new SneInstruction());
            this._cpuInstructionResolvers[0x5] = ((i) => new SeInstruction2());
            this._cpuInstructionResolvers[0x6] = ((i) => new LdInstruction());
            this._cpuInstructionResolvers[0x7] = ((i) => new AddInstruction());
            this._cpuInstructionResolvers[0x8] = InstructionResolverHelpers.Resolve0x8;
            this._cpuInstructionResolvers[0x9] = ((i) => new SneInstruction2());
            this._cpuInstructionResolvers[0xA] = ((i) => new LdInstruction3());
            this._cpuInstructionResolvers[0xB] = ((i) => new JpInstruction2());
            this._cpuInstructionResolvers[0xC] = null;
            this._cpuInstructionResolvers[0xD] = null;
            this._cpuInstructionResolvers[0xE] = InstructionResolverHelpers.Resolve0xE;
            this._cpuInstructionResolvers[0xF] = InstructionResolverHelpers.Resolve0xF;
           
        }


        public ICpuInstruction ResolveOpcode(ushort opcode)
        {
            byte identifier = (byte)(opcode & 0xF000 >> 8);

            return this._cpuInstructionResolvers[identifier].Invoke(opcode);
        }
    }
}
