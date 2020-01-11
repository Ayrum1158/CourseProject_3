using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DBI;

namespace CourseProject_Layered
{
    public partial class MotherboardEditForm : Form
    {
        private DB_interface DB_Interface;
        private DataGridView MainDGV;

        public MotherboardEditForm(DB_interface dbi, DataGridView dgv)
        {
            InitializeComponent();
            DB_Interface = dbi;
            MainDGV = dgv;
        }

        private void MotherboardEditForm_Load(object sender, EventArgs e)
        {
            ManufacturerComboBox.DataSource = Enum.GetValues(typeof(Manufacturer));
            SocketComboBox.DataSource = Enum.GetValues(typeof(SocketType));
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            Motherboard motherboard = new Motherboard((int)IDNumericUpDown.Value, (Manufacturer)ManufacturerComboBox.SelectedItem,
                                                        (SocketType)SocketComboBox.SelectedItem, (int)SlotsNumericUpDown.Value);
            if(motherboard.WriteToDB(DB_Interface))
            {
                MainDGV.CurrentRow.Cells[1].Value = motherboard.ID;
            }
        }
    }
}
