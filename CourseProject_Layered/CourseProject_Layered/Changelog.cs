using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBI;

namespace CourseProject_Layered
{
    public class Changelog : IDB_Write, IDB_Read
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
            return DBI_obj.InsertInto("Changelogs", new string[] { "Changelog_id", "Logged_change" }, new object[] { ID, Logged_change });
        }

        public object[] ReadFromDB(DB_interface DBI_obj)
        {
            return DBI_obj.SelectRowsWhere("Changelogs", "Changelog_id", ID.ToString());
        }

        public void DeleteFromDB(DB_interface DBI_obj)
        {
            DBI_obj.DeleteRowsWhere("Changelogs", "Changelog_id", ID.ToString());
        }
    }
}
