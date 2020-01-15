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

        public Computer NewComp { get; private set; }

        public CreateComputerForm(DB_interface dbi)
        {
            InitializeComponent();
            DB_Interface = dbi;
        }

        private void CreateComputerForm_Load(object sender, EventArgs e)
        {
            InventoryNumberTextBox.Select();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
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
                NewComp = new Computer(InventoryNumberTextBox.Text);
                if (NewComp.WriteToDB(DB_Interface))
                {
                    this.DialogResult = DialogResult.OK;
                }
                this.Close();
            }
        }
    }
}
