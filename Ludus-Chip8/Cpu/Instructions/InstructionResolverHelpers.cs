using Ludus_Chip8.Cpu.Instructions.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludus_Chip8.Cpu.Instructions
{
    public class InstructionResolverHelpers
    {
        public static ICpuInstruction Resolve0x0(ushort opcode)
        {
            byte command = (byte)(opcode & 0x00FF);

            if(command == 0xE0)
            {
                return new ClsInstruction();
            }
            else if(command == 0xEE)
            {
                return new RetInstruction();
            }

            throw new Exception(String.Format("Failed to find instruction for {0:x4}", opcode.ToString()));
        }

        public static ICpuInstruction Resolve0x8(ushort opcode)
        {
            byte command = (byte)(opcode & 0x000F);

            switch (command)
            {
                case 0x00:
                    return new LdInstruction2();
                case 0x01:
                    return new BitwiseOrInstruction();
                case 0x02:
                    return new BitwiseAndInstruction();
                case 0x03:
                    return new BitwiseOrInstruction();
                case 0x04:
                    return new AddInstruction2();
                case 0x05:
                    return new SubInstruction();
                case 0x06:
                    return new ShrInstruction();
                case 0x07:
                    return new SubnInstruction();
                case 0x0E:
                    return new ShlInstruction();
            }

            throw new Exception(String.Format("Failed to find instruction for {0:x4}", opcode.ToString()));
        }

        public static ICpuInstruction Resolve0xE(ushort opcode)
        {
            byte command = (byte)(opcode & 0x00FF);

            switch (command)
            {
                case 0x009E:
                    throw new NotImplementedException();
                case 0x00A1:
                    throw new NotImplementedException();
            }

            return null;
        }

        public static ICpuInstruction Resolve0xF(ushort opcode)
        {
            byte command = (byte)(opcode & 0x00FF);

            switch (command)
            {
                case 0x0007:
                    throw new NotImplementedException();
                case 0x000A:
                    throw new NotImplementedException();
                case 0x0015:
                    throw new NotImplementedException();
                case 0x0018:
                    throw new NotImplementedException();
                case 0x001E:
                    throw new NotImplementedException();
                case 0x0029:
                    throw new NotImplementedException();
                case 0x0033:
                    throw new NotImplementedException();
                case 0x0055:
                    throw new NotImplementedException();
                case 0x65:
                    throw new NotImplementedException();
            }
        }
    }
}
