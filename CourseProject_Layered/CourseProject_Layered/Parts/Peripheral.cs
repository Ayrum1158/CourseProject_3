using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject_Layered.Parts
{
    class Peripheral
    {
        public PeripheralType PT { get; private set; }
        public string Name { get; private set; }
        public string Performance { get; private set; }

        public Peripheral(PeripheralType pt, string name, string performance)
        {
            PT = pt;
            Name = name;
            Performance = performance;
        }
    }
}
