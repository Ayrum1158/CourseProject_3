using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DBI;

namespace CourseProject_Layered
{
    public partial class RAMEditForm : Form
    {
        public RAM ram;

        private DB_interface DB_Interface;

        public RAMEditForm(DB_interface dbi)
        {
            InitializeComponent();
            DB_Interface = dbi;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void RAMEditForm_Load(object sender, EventArgs e)
        {
            TypeComboBox.DataSource = Enum.GetValues(typeof(RAM_Type));
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            ram = new RAM((int)IDNumericUpDown.Value, (int)VolumeNumericUpDown.Value, (RAM_Type)TypeComboBox.SelectedItem, 
                (int)FrequencyNumericUpDown.Value, (int)StickCountNumericUpDown.Value);
            if(ram.WriteToDB(DB_Interface))
            {
                this.DialogResult = DialogResult.OK;
            }
            this.Close();
        }
    }
}
