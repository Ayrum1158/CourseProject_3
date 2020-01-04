using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject_Layered
{
    class Motherboard
    {
        public Manufacturer MF { get; private set; }
        public SocketType ST { get; private set; }
        public uint RAM_Slots { get; private set; }

        public Motherboard(Manufacturer mf, SocketType st, uint ram_slots)
        {
            MF = mf;
            ST = st;
            RAM_Slots = ram_slots;
        }
    }
}
