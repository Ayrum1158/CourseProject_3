using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DBI;
using System.Data.SqlClient;

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

        private const int ElementsInCP = 6;
        private DB_interface DB_Interface;

        private int ComputersCount;

        public ComputerPartsForm()
        {
            InitializeComponent();
            DB_Interface = new DB_interface(DB_ConstructorMode.InFolder);
        }

        private void ComputerPartsForm_Load(object sender, EventArgs e)
        {
        
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

            SaveToDBButton.Enabled = true;
            CreateComputerButton.Enabled = true;
            RemoveComputerButton.Enabled = true;
            EditMotherboardButton.Enabled = true;

            ShowChangelogButton.Enabled = true;
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

                    var temp = DB_Interface.InsertInto("ComputerParts (InventoryNumber)", new string[] { "InventoryNumber" }, new object[] { InventoryNumber }, true);
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
            CreateComputerForm ccf = new CreateComputerForm(DB_Interface, MainDGV);
            ccf.ShowDialog(this);
            if (ccf.ComputerAdded)
                ComputersCount++;
        }

        private void RemoveComputerButton_Click(object sender, EventArgs e)
        {
            if (MainDGV.Rows.Count > 0)
            {
                DB_Interface.DeleteRows("ComputerParts", "InventoryNumber", MainDGV.CurrentRow.Cells[0].Value.ToString());
                MainDGV.Rows.Remove(MainDGV.CurrentRow);
                ComputersCount--;
            }
        }

        private void ShowChangelogButton_Click(object sender, EventArgs e)
        {
            PeripheralsListBox.Items.Clear();
            if (MainDGV.Rows.Count > 0)
            {
                object[] Changelog = DB_Interface.SelectRowWhere("Changelogs", "Changelogs_id", MainDGV.CurrentRow.Cells[5].Value.ToString());
                for(int i = 1; i < Changelog.Length; i+=2)
                {
                    PeripheralsListBox.Items.Add(Changelog[i]);
                }
            }
        }

        private void EditMotherboardButton_Click(object sender, EventArgs e)
        {
            MotherboardEditForm mef = new MotherboardEditForm(DB_Interface, MainDGV);
            mef.ShowDialog(this);
        }
    }
}
