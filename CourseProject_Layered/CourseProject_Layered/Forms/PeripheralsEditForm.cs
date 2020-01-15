using System;
using System.Windows.Forms;
using DBI;

namespace CourseProject_Layered
{
    public partial class PeripheralsEditForm : Form
    {
        private DB_interface DB_Interface;
        public Peripheral peripheral { get; private set; }

        public PeripheralsEditForm(DB_interface dbi)
        {
            InitializeComponent();
            DB_Interface = dbi;
        }

        private void PeripheralsEditForm_Load(object sender, EventArgs e)
        {
            TypeComboBox.DataSource = Enum.GetValues(typeof(PeripheralType));
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            peripheral = new Peripheral((int)IDNumericUpDown.Value, (PeripheralType)TypeComboBox.SelectedItem, NameTextBox.Text, PerformanceTextBox.Text);
            if (NameTextBox.Text.Length > 0)
            {
                if (peripheral.WriteToDB(DB_Interface))
                {
                    this.DialogResult = DialogResult.OK;
                }
            }
            else
            {
                MessageBox.Show("Enter device name.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.Close();
        }
    }
}
