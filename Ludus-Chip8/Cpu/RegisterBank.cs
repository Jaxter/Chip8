using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludus_Chip8.Cpu
{
    public class RegisterBank
    {
        private byte[] _v;

        public ushort PC;
        public ushort I;

        public byte[] V { get { return this.V; } }

        public RegisterBank()
        {

        }
    }
}
