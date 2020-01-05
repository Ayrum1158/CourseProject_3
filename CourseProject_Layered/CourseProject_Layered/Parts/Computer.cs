using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBI;
using System.Text.RegularExpressions;

namespace CourseProject_Layered.Parts
{
    class Computer : IDB_Write, IDB_Read
    {
        private List<Changelog> ChangelogList;
        private List<Peripheral> PeripheralsList;
        private long Changelogs_id;

        private string _inventoryNumber;
        private CPU _curCPU;
        private Motherboard _curMotherboard;
        private RAM _curRAM;
        private List<Peripheral> _peripherals;

        public string InventoryNumber
        {
            get
            {
                return _inventoryNumber;
            }
            private set
            {
                Regex r = new Regex("^[a-zA-Z0-9]*$");
                if (r.IsMatch(value))
                {
                    _inventoryNumber = value;
                }
                else
                    throw new FormatException("Alphanumeric characters only.");
            }
        }

        public CPU CurCPU
        {
            get { return _curCPU; }
            set
            {
                _curCPU = value;
                ChangelogList.Add(new Changelog(Changelogs_id, "Installed CPU with ID number:" + value.ID.ToString()));
            }
        }
        public Motherboard CurMotherboard
        {
            get { return _curMotherboard; }
            set
            {
                _curMotherboard = value;
                ChangelogList.Add(new Changelog(Changelogs_id, "Installed Motherboard with ID number:" + value.ID.ToString()));
            }
        }
        public RAM CurRAM
        {
            get { return _curRAM; }
            set
            {
                _curRAM = value;
                ChangelogList.Add(new Changelog(Changelogs_id, "Installed RAM with ID number:" + value.ID.ToString()));
            }
        }
        

        public Computer(string inventoryNumber)
        {
            InventoryNumber = inventoryNumber;
            Changelogs_id = Base36ToBase10(InventoryNumber);
            ChangelogList = new List<Changelog>();
        }

        public void WriteToDB(DB_interface DBI_obj)
        {
            CurCPU.WriteToDB(DBI_obj);
            CurMotherboard.WriteToDB(DBI_obj);
            CurRAM.WriteToDB(DBI_obj);
            foreach (var i in PeripheralsList)
            {
                i.WriteToDB(DBI_obj);
            }
            DBI_obj.InsertInto("ComputerParts", new string[] { "InventoryNumber", "Motherboard_id", "RAM_id", "Peripherals_id", "CPU_id", "Changelogs_id" },
                                                new object[] { InventoryNumber, CurMotherboard.ID, CurRAM.ID, PeripheralsList, CurCPU.ID, Changelogs_id });

        }

        public object[] ReadFromDB(DB_interface DBI_obj)
        {
            return DBI_obj.SelectAllFrom("ComputerParts");
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
