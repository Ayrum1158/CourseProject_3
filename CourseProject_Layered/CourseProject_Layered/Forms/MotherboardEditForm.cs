using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DBI;

namespace CourseProject_Layered
{
    public partial class MotherboardEditForm : Form
    {
        private DB_interface DB_Interface;

        public Motherboard motherboard { get; private set; }

        public MotherboardEditForm(DB_interface dbi, DataGridView dgv)
        {
            InitializeComponent();
            DB_Interface = dbi;
        }

        private void MotherboardEditForm_Load(object sender, EventArgs e)
        {
            ManufacturerComboBox.DataSource = Enum.GetValues(typeof(Manufacturer));
            SocketComboBox.DataSource = Enum.GetValues(typeof(SocketType));
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            motherboard = new Motherboard((int)IDNumericUpDown.Value, (Manufacturer)ManufacturerComboBox.SelectedItem,
                                                        (SocketType)SocketComboBox.SelectedItem, (int)SlotsNumericUpDown.Value);
            if (motherboard.WriteToDB(DB_Interface))
            {
                this.DialogResult = DialogResult.OK;
            }
            this.Close();
        }
    }
}
