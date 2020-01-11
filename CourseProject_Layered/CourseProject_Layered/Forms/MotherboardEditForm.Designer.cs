namespace CourseProject_Layered
{
    partial class MotherboardEditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.IDNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.SlotsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.ManufacturerComboBox = new System.Windows.Forms.ComboBox();
            this.SocketComboBox = new System.Windows.Forms.ComboBox();
            this.CancelButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.IDNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlotsNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Motherboard ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(156, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Manufacturer";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(294, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Socket";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "RAM slots";
            // 
            // IDNumericUpDown
            // 
            this.IDNumericUpDown.Location = new System.Drawing.Point(13, 30);
            this.IDNumericUpDown.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.IDNumericUpDown.Name = "IDNumericUpDown";
            this.IDNumericUpDown.Size = new System.Drawing.Size(98, 20);
            this.IDNumericUpDown.TabIndex = 4;
            // 
            // SlotsNumericUpDown
            // 
            this.SlotsNumericUpDown.Location = new System.Drawing.Point(12, 81);
            this.SlotsNumericUpDown.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.SlotsNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SlotsNumericUpDown.Name = "SlotsNumericUpDown";
            this.SlotsNumericUpDown.Size = new System.Drawing.Size(99, 20);
            this.SlotsNumericUpDown.TabIndex = 5;
            this.SlotsNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ManufacturerComboBox
            // 
            this.ManufacturerComboBox.FormattingEnabled = true;
            this.ManufacturerComboBox.Location = new System.Drawing.Point(159, 30);
            this.ManufacturerComboBox.Name = "ManufacturerComboBox";
            this.ManufacturerComboBox.Size = new System.Drawing.Size(106, 21);
            this.ManufacturerComboBox.TabIndex = 6;
            // 
            // SocketComboBox
            // 
            this.SocketComboBox.FormattingEnabled = true;
            this.SocketComboBox.Location = new System.Drawing.Point(297, 30);
            this.SocketComboBox.Name = "SocketComboBox";
            this.SocketComboBox.Size = new System.Drawing.Size(106, 21);
            this.SocketComboBox.TabIndex = 7;
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(348, 89);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 8;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(260, 89);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 9;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // MotherboardEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 124);
            this.ControlBox = false;
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SocketComboBox);
            this.Controls.Add(this.ManufacturerComboBox);
            this.Controls.Add(this.SlotsNumericUpDown);
            this.Controls.Add(this.IDNumericUpDown);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "MotherboardEditForm";
            this.Text = "Motherboard edit";
            this.Load += new System.EventHandler(this.MotherboardEditForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.IDNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlotsNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown IDNumericUpDown;
        private System.Windows.Forms.NumericUpDown SlotsNumericUpDown;
        private System.Windows.Forms.ComboBox ManufacturerComboBox;
        private System.Windows.Forms.ComboBox SocketComboBox;
        private new System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button OKButton;
    }
}