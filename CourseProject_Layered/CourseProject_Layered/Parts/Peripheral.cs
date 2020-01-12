using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBI;

namespace CourseProject_Layered
{
    public class Peripheral: IDB_Write, IDB_Read
    {
        public int ID { get; private set; }
        public PeripheralType PT { get; private set; }
        public string Name { get; private set; }
        public string Performance { get; private set; }

        public Peripheral(int id, PeripheralType pt, string name, string performance)
        {
            ID = id;
            PT = pt;
            Name = name;
            Performance = performance;
        }

        public bool WriteToDB(DB_interface DBI_obj)
        {
            return DBI_obj.InsertInto("Peripheral", new string[] { "Peripheral_id", "Type", "Name", "Performance" }, new object[] { ID, PT, Name, Performance });
        }

        public object[] ReadFromDB(DB_interface DBI_obj)
        {
            return DBI_obj.SelectRowsWhere("Peripheral", "Peripheral_id", ID.ToString());
        }
    }
}
