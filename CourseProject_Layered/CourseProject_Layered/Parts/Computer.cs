using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBI;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace CourseProject_Layered
{
    public class Computer : IDB_Write, IDB_Read
    {
        private string _inventoryNumber;
        private CPU _curCPU;
        private Motherboard _curMotherboard;
        private RAM _curRAM;

        public List<Changelog> ChangelogList { get; private set; }
        public List<Peripheral> PeripheralsList { get; private set; }
        public long PeripheralsChangelogs_id { get; private set; }
        public string InventoryNumber
        {
            get { return _inventoryNumber; }
            private set
            {
                Regex r = new Regex("^[a-zA-Z0-9]*$");
                if (r.IsMatch(value))
                {
                    _inventoryNumber = value;
                }
                else
                    throw new FormatException("Alphanumeric characters only.");
                PeripheralsChangelogs_id = Base36ToBase10(_inventoryNumber);//generating changelogs id using InventoryNumber
                ChangelogList.Add(new Changelog(PeripheralsChangelogs_id, "New computer created, inventory number: " + value));
            }
        }
        public CPU CurCPU
        {
            get { return _curCPU; }
            set
            {
                bool AllowSet = false;
                if (CurCPU != null)
                {
                    if (CurMotherboard.ST == value.ST)
                    {
                        AllowSet = true;
                    }
                }
                else//if null
                {
                    AllowSet = true;
                }
                if (AllowSet)
                {
                    _curCPU = value;
                    ChangelogList.Add(new Changelog(PeripheralsChangelogs_id, "Installed CPU with ID number:" + value.ID.ToString()));
                }
            }
        }
        public Motherboard CurMotherboard
        {
            get { return _curMotherboard; }
            set
            {
                bool AllowSet = false;
                if (CurCPU != null)
                {
                    if (CurCPU.ST == value.ST)
                    {
                        AllowSet = true;
                    }
                }
                else//if null
                {
                    AllowSet = true;
                }
                if (AllowSet)
                {
                    _curMotherboard = value;
                    ChangelogList.Add(new Changelog(PeripheralsChangelogs_id, "Installed Motherboard with ID number:" + value.ID.ToString()));
                }
            }
        }
        public RAM CurRAM
        {
            get { return _curRAM; }
            set
            {
                bool AllowSet = false;
                if (CurMotherboard != null)
                {
                    if (CurMotherboard.RAM_Slots >= value.StickCount)
                    {
                        AllowSet = true;
                    }
                }
                else//if null
                {
                    AllowSet = true;
                }
                if(AllowSet)
                {
                    _curRAM = value;
                    ChangelogList.Add(new Changelog(PeripheralsChangelogs_id, "Installed RAM with ID number:" + value.ID.ToString()));
                }
            }
        }

        public Computer(string inventoryNumber)
        {
            ChangelogList = new List<Changelog>();
            PeripheralsList = new List<Peripheral>();
            InventoryNumber = inventoryNumber;
        }

        public bool WriteToDB(DB_interface DBI_obj)//first write or update records
        {
            if(CurCPU != null)
                CurCPU.WriteToDB(DBI_obj);

            if (CurMotherboard != null)
                CurMotherboard.WriteToDB(DBI_obj);

            if (CurRAM != null)
                CurRAM.WriteToDB(DBI_obj);

            if(PeripheralsList.Count > 0)
                foreach (var i in PeripheralsList)
                { i.WriteToDB(DBI_obj); }

            if(ChangelogList.Count > 0)
                foreach (var i in ChangelogList)
                { i.WriteToDB(DBI_obj); }

            bool result;

            try
            {
                result = DBI_obj.InsertInto("ComputerParts", new string[] { "InventoryNumber", "Motherboard_id", "RAM_id", "Peripherals_id", "CPU_id", "PeripheralsChangelogs_id" },
                                                    new object[] { InventoryNumber, CurMotherboard.ID, CurRAM.ID, PeripheralsChangelogs_id, CurCPU.ID, PeripheralsChangelogs_id });
            }
            catch (NullReferenceException)//if not all components are in computer
            {
                result = DBI_obj.InsertInto("ComputerParts (InventoryNumber)", new string[] { "InventoryNumber" }, new object[] { InventoryNumber });
            }
            finally
            {
                if (CurMotherboard != null)
                    DBI_obj.UpdateWhere("ComputerParts", new string[] { "Motherboard_id" }, new object[] { CurMotherboard.ID }, "InventoryNumber", InventoryNumber);
                if (CurRAM != null)
                    DBI_obj.UpdateWhere("ComputerParts", new string[] { "RAM_id" }, new object[] { CurRAM.ID }, "InventoryNumber", InventoryNumber);
                
                DBI_obj.UpdateWhere("ComputerParts", new string[] { "Peripherals_id" }, new object[] { PeripheralsChangelogs_id }, "InventoryNumber", InventoryNumber);

                if (CurCPU != null)
                    DBI_obj.UpdateWhere("ComputerParts", new string[] { "CPU_id" }, new object[] { CurCPU.ID }, "InventoryNumber", InventoryNumber);
                
                DBI_obj.UpdateWhere("ComputerParts", new string[] { "Changelog_id" }, new object[] { PeripheralsChangelogs_id }, "InventoryNumber", InventoryNumber);
            }
            return result;
        }

        public object[] ReadFromDB(DB_interface DBI_obj)//read all ID's
        {
            return DBI_obj.SelectRowsWhere("ComputerParts", "InventoryNumber", InventoryNumber);
        }

        public Computer ReadFromDBFull(DB_interface DBI_obj)//read whole Computer structure
        {
            var IDs = DBI_obj.SelectRowsWhere("ComputerParts", "InventoryNumber", InventoryNumber);//6 elements

            var ReadMotherboard = DBI_obj.SelectRowsWhere("Motherboards", "Motherboard_id", IDs[1].ToString());
            var ReadRAM = DBI_obj.SelectRowsWhere("RAMs", "RAM_id", IDs[2].ToString());
            var ReadPeripherals = DBI_obj.SelectRowsWhere("Peripheral", "Peripheral_id", IDs[3].ToString());
            var ReadCPU = DBI_obj.SelectRowsWhere("CPUs", "CPU_id", IDs[4].ToString());
            var ReadChangelog = DBI_obj.SelectRowsWhere("Changelogs", "Changelog_id", IDs[5].ToString());

            if(ReadMotherboard.Length > 0)
            {
                Motherboard RMB = new Motherboard((int)ReadMotherboard[0], (Manufacturer)Enum.Parse(typeof(Manufacturer), ReadMotherboard[1].ToString()),
                    (SocketType)Enum.Parse(typeof(SocketType), ReadMotherboard[2].ToString()), (int)ReadMotherboard[3]);
                CurMotherboard = RMB;
            }
            if (ReadRAM.Length > 0)
            {
                RAM_Type rtype = (RAM_Type)Enum.Parse(typeof(RAM_Type), ReadRAM[3].ToString());
                //RAM RR = new RAM((int)ReadRAM[0], (int)ReadRAM[1], (int)ReadRAM[2]), ,(int)ReadRAM[4]);
                RAM RR = new RAM((int)ReadRAM[0], (int)ReadRAM[1], (RAM_Type)Enum.Parse(typeof(RAM_Type), ReadRAM[2].ToString()), (int)ReadRAM[3], (int)ReadRAM[4]);
                //(RAM_Type)Enum.Parse(typeof(RAM_Type), "");
                CurRAM = RR;
            }
            if(ReadCPU.Length > 0)// by some reason DataReader reads SocketType as int, Frequency as string
            {
                CPU RC = new CPU((int)ReadCPU[0], (SocketType)Enum.Parse(typeof(SocketType), ReadCPU[1].ToString()), int.Parse(ReadCPU[2].ToString()));
                CurCPU = RC;
            }
            if(ReadChangelog.Length > 0)
            {
                List<Changelog> RCL = new List<Changelog>();
                for(int i = 0; i < ReadChangelog.Length; i+=2)
                {                
                    Changelog change = new Changelog(long.Parse(ReadChangelog[i].ToString()), ReadChangelog[i + 1].ToString());
                    RCL.Add(change);
                }
                List<Changelog> ChangelogList = RCL;
            }
            if(ReadPeripherals.Length > 0)
            {
                List<Peripheral> RPL = new List<Peripheral>();
                for (int i = 0; i < ReadPeripherals.Length; i += 4)
                {
                    Peripheral peripheral = new Peripheral((int)ReadPeripherals[i], (PeripheralType)Enum.Parse(typeof(PeripheralType),
                        ReadPeripherals[i + 1].ToString()), ReadPeripherals[i + 2].ToString(), ReadPeripherals[i + 3].ToString());
                    RPL.Add(peripheral);
                }
                PeripheralsList = RPL;
            }
            return this;
        }

        private long Base36ToBase10(string input)
        {
            const string CharList = "0123456789abcdefghijklmnopqrstuvwxyz";
            var reversed = input.ToLower().Reverse();
            long result = 0;
            int pos = 0;
            foreach (char c in reversed)
            {
                result += CharList.IndexOf(c) * (long)Math.Pow(36, pos);
                pos++;
            }
            return result;
        }

        public void AddPeripheral(Peripheral peripheral)
        {
            foreach(var i in PeripheralsList)
            {
                if (i.ID == peripheral.ID)
                {
                    throw new InvalidOperationException("Same ID found, primary key violation in future.");
                }
            }           
            PeripheralsList.Add(peripheral);
        }
    }
}
