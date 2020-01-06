using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBI;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace CourseProject_Layered
{
    class Computer : IDB_Write, IDB_Read
    {
        private List<Changelog> ChangelogList;
        private List<Peripheral> PeripheralsList;
        private long PeripheralsChangelogs_id;

        private string _inventoryNumber;
        private CPU _curCPU;
        private Motherboard _curMotherboard;
        private RAM _curRAM;

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
            PeripheralsChangelogs_id = Base36ToBase10(InventoryNumber);//generating changelogs id using InventoryNumber
        }

        public void WriteToDB(DB_interface DBI_obj)//first write or update records
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

            //bool InsertResult = true;

            try
            {
                DBI_obj.InsertInto("ComputerParts", new string[] { "InventoryNumber", "Motherboard_id", "RAM_id", "Peripherals_id", "CPU_id", "PeripheralsChangelogs_id" },
                                                    new object[] { InventoryNumber, CurMotherboard.ID, CurRAM.ID, PeripheralsChangelogs_id, CurCPU.ID, PeripheralsChangelogs_id });
            }
            catch (NullReferenceException)//if not all components are in computer
            {
                /*InsertResult = */DBI_obj.InsertInto("ComputerParts (InventoryNumber)", new string[] { "InventoryNumber" }, new object[] { InventoryNumber });
            }
            finally
            {
                //if(!InsertResult)
                //    $$
                if (CurMotherboard != null)
                    DBI_obj.UpdateWhere("ComputerParts", new string[] { "Motherboard_id" }, new object[] { CurMotherboard.ID }, "InventoryNumber", InventoryNumber);
                if (CurRAM != null)
                    DBI_obj.UpdateWhere("ComputerParts", new string[] { "RAM_id" }, new object[] { CurRAM.ID }, "InventoryNumber", InventoryNumber);
                
                DBI_obj.UpdateWhere("ComputerParts", new string[] { "Peripherals_id" }, new object[] { PeripheralsChangelogs_id }, "InventoryNumber", InventoryNumber);

                if (CurCPU != null)
                    DBI_obj.UpdateWhere("ComputerParts", new string[] { "CPU_id" }, new object[] { CurCPU.ID }, "InventoryNumber", InventoryNumber);
                
                DBI_obj.UpdateWhere("ComputerParts", new string[] { "Changelog_id" }, new object[] { PeripheralsChangelogs_id }, "InventoryNumber", InventoryNumber);
            }
        }

        public object[] ReadFromDB(DB_interface DBI_obj)
        {
            return DBI_obj.SelectRowWhere("ComputerParts", "InventoryNumber", InventoryNumber);
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
