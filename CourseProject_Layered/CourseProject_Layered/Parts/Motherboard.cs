using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBI;

namespace CourseProject_Layered
{
    public class Motherboard : IDB_Write, IDB_Read
    {
        public int ID { get; private set; }
        public Manufacturer MF { get; private set; }
        public SocketType ST { get; private set; }
        public int RAM_Slots { get; private set; }

        public Motherboard(int id, Manufacturer mf, SocketType st, int ram_slots)
        {
            ID = Math.Abs(id);
            MF = mf;
            ST = st;
            RAM_Slots = ram_slots;
        }

        public bool WriteToDB(DB_interface DBI_obj)
        {
            return DBI_obj.InsertInto("Motherboards", new string[] { "Motherboard_id", "Manufacturer", "Socket", "RAM_Slots" }, new object[] { ID, MF, ST, RAM_Slots });
        }

        public object[] ReadFromDB(DB_interface DBI_obj)
        {
            return DBI_obj.SelectAllFrom("Motherboards");
        }
    }
}
