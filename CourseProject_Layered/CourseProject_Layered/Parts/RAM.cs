using System;
using DBI;

namespace CourseProject_Layered
{
    public class RAM : IDB_Write, IDB_Read
    {
        public int ID { get; private set; }//always pisitive
        public int Volume { get; private set; }//in Mb
        public int Frequency { get; private set; }//in MHz
        public RAM_Type RT { get; private set; }
        public int StickCount { get; private set; }

        public RAM(int id, int volume, RAM_Type rt, int frequency, int stickCount)
        {
            ID = Math.Abs(id);
            RT = rt;
            Frequency = Math.Abs(frequency);
            Volume = Math.Abs(volume);
            StickCount = Math.Abs(stickCount);
        }

        public bool WriteToDB(DB_interface DBI_obj)
        {
            return DBI_obj.InsertInto("RAMs", new string[] { "RAM_id", "Volume", "Type", "StickCount", "Frequency" }, new object[] { ID, Volume, RT.ToString(), StickCount, Frequency });
        }

        public object[] ReadFromDB(DB_interface DBI_obj)
        {
            return DBI_obj.SelectRowsWhere("RAMs", "RAM_id", ID.ToString());
        }
    }
}
