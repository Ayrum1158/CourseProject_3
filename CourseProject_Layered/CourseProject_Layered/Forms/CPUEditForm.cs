using System;
using System.Windows.Forms;
using DBI;

namespace CourseProject_Layered
{
    public partial class CPUEditForm : Form
    {
        private DB_interface DB_Interface;

        public CPU cpu;

        public CPUEditForm(DB_interface dbi)
        {
            InitializeComponent();
            DB_Interface = dbi;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void CPUEditForm_Load(object sender, EventArgs e)
        {
            SocketComboBox.DataSource = Enum.GetValues(typeof(SocketType));
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            cpu = new CPU((int)IDNumericUpDown.Value, (SocketType)SocketComboBox.SelectedItem, (int)FrequencyNumericUpDown.Value);
            if(cpu.WriteToDB(DB_Interface))
            {
                this.DialogResult = DialogResult.OK;
            }
            this.Close();
        }
    }
}
