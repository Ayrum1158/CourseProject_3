using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBI;

namespace CourseProject_Layered
{
    class Changelog : IDB_Write, IDB_Read
    {
        public long ID { get; private set; }
        public string Logged_change { get; private set; }

        public Changelog(long id, string change)
        {
            ID = id;
            Logged_change = change;
        }

        public bool WriteToDB(DB_interface DBI_obj)
        {
            return DBI_obj.InsertInto("Changelogs", new string[] { "Changelogs_id", "Logged_change" }, new object[] { ID, Logged_change });
        }

        public object[] ReadFromDB(DB_interface DBI_obj)
        {
            return DBI_obj.SelectRowWhere("Changelogs", "Changelogs_id", ID.ToString());
        }
    }
}
