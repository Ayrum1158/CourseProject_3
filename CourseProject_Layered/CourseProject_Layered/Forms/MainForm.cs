using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DBI;
//using System.Data.SqlClient;

namespace CourseProject_Layered
{
    public partial class ComputerPartsForm : Form
    {
        // to be able to drag window start
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        // to be able to drag window end

        public DB_interface DB_Interface { get; private set; }

        private const int ElementsInCP = 6;
        private int ComputersCount;
        private List<Computer> Computers;

        public ComputerPartsForm()
        {
            InitializeComponent();
            DB_Interface = new DB_interface(DB_ConstructorMode.InFolder);
            Computers = new List<Computer>();
        }

        private void CloseLabel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TopLable_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void LoadDBButton_Click(object sender, EventArgs e)
        {
            object[] SelectResult = DB_Interface.SelectAllFrom("ComputerParts");

            ComputersCount = SelectResult.Length / ElementsInCP;

            DataTable MainDT = new DataTable();

            MainDT.Columns.Add("InventoryNumber", typeof(string));
            MainDT.Columns.Add("Motherboard_id", typeof(int));
            MainDT.Columns.Add("RAM_id", typeof(int));
            MainDT.Columns.Add("Peripherals_id", typeof(long));
            MainDT.Columns.Add("CPU_id", typeof(int));
            MainDT.Columns.Add("Changelog_id", typeof(long));

            if (SelectResult.Length != 0)
            {
                for (int i = 0; i < SelectResult.Length; i += ElementsInCP)
                {
                    DataRow row = MainDT.NewRow();
                    row["InventoryNumber"] = SelectResult[i];
                    row["Motherboard_id"] = SelectResult[i + 1];
                    row["RAM_id"] = SelectResult[i + 2];
                    row["Peripherals_id"] = SelectResult[i + 3];
                    row["CPU_id"] = SelectResult[i + 4];
                    row["Changelog_id"] = SelectResult[i + 5];

                    MainDT.Rows.Add(row);
                }
            }

            MainDGV.DataSource = MainDT;

            foreach (DataGridViewColumn dgvc in MainDGV.Columns)
            {
                dgvc.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            var DT = (DataTable)MainDGV.DataSource;

            Computers.Clear();

            for (int i = 0; i < ComputersCount; i++)
            {
                Computer NewComp = new Computer(DT.Rows[i].ItemArray[0].ToString());
                NewComp.ReadFromDBFull(DB_Interface);
                Computers.Add(NewComp);
            }

            SaveToDBButton.Enabled = true;
            CreateComputerButton.Enabled = true;
            RemoveComputerButton.Enabled = true;
            EditMotherboardButton.Enabled = true;
            EditRAMButton.Enabled = true;
            EditCPUButton.Enabled = true;
            AddPeripheralsButton.Enabled = true;
        }

        private void SaveToDBButton_Click(object sender, EventArgs e)
        {
            DataTable MainDT = (DataTable)MainDGV.DataSource;

            string[] CPColsNames = new string[ElementsInCP-1];//without first
            for (int i = 0; i < ElementsInCP-1; i++)
                CPColsNames[i] = MainDT.Columns[i+1].ColumnName;

            if (MainDT.Rows.Count != 0)
            {
                for (int i = 0; i < ComputersCount; i++)
                {
                    string InventoryNumber = (string)MainDT.Rows[i].ItemArray[0];

                    DB_Interface.InsertInto("ComputerParts (InventoryNumber)", new string[] { "InventoryNumber" }, new object[] { InventoryNumber }, true);
                    for(int j = 0; j < ElementsInCP-1; j++)
                    {
                        if (MainDT.Rows[i].ItemArray[j + 1] != DBNull.Value)
                            DB_Interface.UpdateWhere("ComputerParts", new string[] { CPColsNames[j] }, new object[] { MainDT.Rows[i].ItemArray[j + 1] }, "InventoryNumber", InventoryNumber);
                    }
                }
            }
        }

        private void FillTestValuesButtons_Click(object sender, EventArgs e)
        {
            Computer[] comp = new Computer[3];
            comp[0] = new Computer("1A");
            comp[1] = new Computer("2B");
            comp[2] = new Computer("3C");
            foreach (var i in comp)
                i.WriteToDB(DB_Interface);
        }

        private void DgvdatasourceclearButton_Click(object sender, EventArgs e)
        {
            MainDGV.DataSource = null;
        }

        private void CreateComputerButton_Click(object sender, EventArgs e)
        {
            CreateComputerForm ccf = new CreateComputerForm(DB_Interface);
            try
            {
                ccf.ShowDialog(this);
            }
            catch (FormatException)
            {
                MessageBox.Show("Alphanumeric latin only.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (ccf.DialogResult == DialogResult.OK)
            {
                for (int i = 0; i < MainDGV.Rows.Count; i++)// is this check needed when we have dialogresult?
                {
                    if ((string)MainDGV.Rows[i].Cells[0].Value == ccf.NewComp.InventoryNumber)
                    {
                        MessageBox.Show("Same ID found. Please enter unique ID.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                DataTable DT = (DataTable)MainDGV.DataSource;
                DataRow row = DT.NewRow();
                row["InventoryNumber"] = ccf.NewComp.InventoryNumber;
                row["Peripherals_id"] = ccf.NewComp.PeripheralsChangelogs_id;
                row["Changelog_id"] = ccf.NewComp.PeripheralsChangelogs_id;
                DT.Rows.Add(row);

                Computers.Add(ccf.NewComp);
                ComputersCount++;
            }
        }

        private void RemoveComputerButton_Click(object sender, EventArgs e)
        {
            if (MainDGV.Rows.Count > 0)
            {
                Computers[MainDGV.CurrentRow.Index].DeleteFromDB(DB_Interface);
                Computers.RemoveAt(MainDGV.CurrentRow.Index);
                MainDGV.Rows.Remove(MainDGV.CurrentRow);
                ComputersCount--;
            }
        }

        private void EditMotherboardButton_Click(object sender, EventArgs e)
        {
            if (MainDGV.Rows.Count > 0)
            {
                MotherboardEditForm mef = new MotherboardEditForm(DB_Interface, MainDGV);
                mef.ShowDialog(this);
                if (mef.DialogResult == DialogResult.OK)
                {
                    Computers[MainDGV.CurrentRow.Index].CurMotherboard = mef.motherboard;
                    if (Computers[MainDGV.CurrentRow.Index].CurMotherboard == mef.motherboard)
                        MainDGV.CurrentRow.Cells[1].Value = mef.motherboard.ID;
                    else
                        MessageBox.Show("Cannot set this motherboard in this computer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void EditRAMButton_Click(object sender, EventArgs e)
        {
            if (MainDGV.Rows.Count > 0)
            {
                RAMEditForm ramef = new RAMEditForm(DB_Interface);
                ramef.ShowDialog(this);
                if(ramef.DialogResult == DialogResult.OK)
                {
                    Computers[MainDGV.CurrentRow.Index].CurRAM = ramef.ram;
                    if (Computers[MainDGV.CurrentRow.Index].CurRAM == ramef.ram)
                        MainDGV.CurrentRow.Cells[2].Value = ramef.ram.ID;
                    else
                        MessageBox.Show("Cannot set this RAM in this computer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void EditCPUButton_Click(object sender, EventArgs e)
        {
            if (MainDGV.Rows.Count > 0)
            {
                CPUEditForm cpuef = new CPUEditForm(DB_Interface);
                cpuef.ShowDialog(this);
                if (cpuef.DialogResult == DialogResult.OK)
                {
                    Computers[MainDGV.CurrentRow.Index].CurCPU = cpuef.cpu;
                    if (Computers[MainDGV.CurrentRow.Index].CurCPU == cpuef.cpu)
                        MainDGV.CurrentRow.Cells[4].Value = cpuef.cpu.ID;
                    else
                        MessageBox.Show("Cannot set this CPU in this computer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void ShowChangelogAndPeripherals()
        {
            ChangelogListBox.Items.Clear();
            PeripheralsListBox.Items.Clear();

            foreach (var i in Computers[MainDGV.CurrentRow.Index].ChangelogList)
            {
                ChangelogListBox.Items.Add(i.Logged_change);
            }
            foreach (var i in Computers[MainDGV.CurrentRow.Index].PeripheralsList)
            {
                PeripheralsListBox.Items.Add($"ID: {i.ID} - {i.Name} - {i.PT.ToString()}");
            }
        }

        private void AddPeripheralsButton_Click(object sender, EventArgs e)
        {
            if (MainDGV.Rows.Count > 0)
            {
                PeripheralsEditForm pef = new PeripheralsEditForm(DB_Interface);
                pef.ShowDialog(this);
                if (pef.DialogResult == DialogResult.OK)
                    Computers[MainDGV.CurrentRow.Index].AddPeripheral(pef.peripheral);
            }
        }

        private void MainDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ShowChangelogAndPeripherals();
        }

        private void ComputerPartsForm_Load(object sender, EventArgs e)
        {

        }
    }
}
