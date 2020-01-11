using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DBI;

namespace CourseProject_Layered
{
    public partial class CreateComputerForm : Form
    {
        private DB_interface DB_Interface;
        private DataGridView MainDGV;

        public bool ComputerAdded = false;

        public CreateComputerForm(DB_interface dbi, DataGridView dgv)
        {
            InitializeComponent();
            DB_Interface = dbi;
            MainDGV = dgv;
        }

        private void CreateComputerForm_Load(object sender, EventArgs e)
        {

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(InventoryNumberTextBox.Text))
            {
                MessageBox.Show("Please, enter inventory number.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DataTable DT = (DataTable)MainDGV.DataSource;
                for(int i = 0; i < MainDGV.Rows.Count; i++)
                {
                    if((string)MainDGV.Rows[i].Cells[0].Value == InventoryNumberTextBox.Text)
                    {
                        MessageBox.Show("Same ID found. Please enter unique ID.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                Computer NewComp = new Computer(InventoryNumberTextBox.Text);
                DataTable MainDT = (DataTable)MainDGV.DataSource;
                DataRow row = MainDT.NewRow();
                row["InventoryNumber"] = NewComp.InventoryNumber;
                row["Peripherals_id"] = NewComp.PeripheralsChangelogs_id;
                row["Changelog_id"] = NewComp.PeripheralsChangelogs_id;
                NewComp.WriteToDB(DB_Interface);
                MainDT.Rows.Add(row);
                ComputerAdded = true;

                this.Close();
            }
        }
    }
}
