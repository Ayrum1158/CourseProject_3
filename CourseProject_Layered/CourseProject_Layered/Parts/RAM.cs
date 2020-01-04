using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBI;

namespace CourseProject_Layered
{
    class RAM : IDB_Write, IDB_Read
    {
        public int ID { get; private set; }//always pisitive
        public double Volume { get; private set; }//in Gb
        public int Frequency { get; private set; }//in MHz
        public RAM_Type RT { get; private set; }
        public int StickCount { get; private set; }

        public RAM(int id, float volume, int frequency, RAM_Type rt, int stickCount)
        {
            ID = Math.Abs(id);
            RT = rt;
            Frequency = Math.Abs(frequency);
            Volume = Math.Abs(volume);
            StickCount = Math.Abs(stickCount);
        }

        public void WriteToDB(DB_interface DBI_obj)
        {
            DBI_obj.InsertInto("RAMs", new string[] { "RAM_id", "Volume", "Type", "StickCount", "Frequency" }, new object[] { ID, Volume, RT.ToString(), StickCount, Frequency });
        }

        public object[] ReadFromDB(DB_interface DBI_obj)
        {
            return DBI_obj.SelectAllFrom("RAMs");
        }
    }
}
