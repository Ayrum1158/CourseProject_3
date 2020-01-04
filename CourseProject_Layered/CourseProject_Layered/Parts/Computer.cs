using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBI;

namespace CourseProject_Layered.Parts
{
    class Computer : IDB_Write, IDB_Read
    {
        public string InventoryNumber { get; private set; }
        public CPU CurCPU { get; private set; }
        public Motherboard CurMotherboard { get; private set; }
        public RAM CurRAM { get; private set; }
        public List<Peripheral> Peripherals { get; private set; }

        public Computer(string inventoryNumber, CPU cpu, Motherboard motherboard, RAM ram, List<Peripheral>)
        {
            InventoryNumber = inventoryNumber;
            CurCPU = cpu;
            CurMotherboard = motherboard;
            CurRAM = ram;
        }

        public void WriteToDB(DB_interface DBI_obj)
        {
            throw new NotImplementedException();
        }

        public object[] ReadFromDB(DB_interface DBI_obj)
        {
            return DBI_obj.SelectAllFrom("ComputerParts");
        }
    }
}
