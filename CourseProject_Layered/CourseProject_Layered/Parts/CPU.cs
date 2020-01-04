using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBI;

namespace CourseProject_Layered
{
    class CPU : IDB_Write, IDB_Read
    {
        public int ID { get; private set; }
        public SocketType ST { get; private set; }
        public int Frequency { get; private set; }

        public CPU(int id, SocketType st, int frequency)
        {
            ID = Math.Abs(id);
            Frequency = Math.Abs(frequency);
            ST = st;
        }

        public void WriteToDB(DB_interface DBI_obj)
        {
            DBI_obj.InsertInto("CPUs", new string[] { "CPU_id", "Socket", "Frequency" }, new object[] { ID, ST, Frequency });
        }

        public object[] ReadFromDB(DB_interface DBI_obj)
        {
            return DBI_obj.SelectAllFrom("CPUs");
        }
    }
}
