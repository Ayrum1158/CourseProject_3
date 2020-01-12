namespace CourseProject_Layered
{
    partial class CPUEditForm
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
            this.IDNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.FrequencyNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.SocketComboBox = new System.Windows.Forms.ComboBox();
            this.CancelButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.IDNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FrequencyNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Frequency";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Socket";
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
            this.IDNumericUpDown.Size = new System.Drawing.Size(85, 20);
            this.IDNumericUpDown.TabIndex = 3;
            // 
            // FrequencyNumericUpDown
            // 
            this.FrequencyNumericUpDown.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.FrequencyNumericUpDown.Location = new System.Drawing.Point(13, 70);
            this.FrequencyNumericUpDown.Maximum = new decimal(new int[] {
            6000,
            0,
            0,
            0});
            this.FrequencyNumericUpDown.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.FrequencyNumericUpDown.Name = "FrequencyNumericUpDown";
            this.FrequencyNumericUpDown.Size = new System.Drawing.Size(85, 20);
            this.FrequencyNumericUpDown.TabIndex = 4;
            this.FrequencyNumericUpDown.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // SocketComboBox
            // 
            this.SocketComboBox.FormattingEnabled = true;
            this.SocketComboBox.Location = new System.Drawing.Point(13, 110);
            this.SocketComboBox.Name = "SocketComboBox";
            this.SocketComboBox.Size = new System.Drawing.Size(85, 21);
            this.SocketComboBox.TabIndex = 5;
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(107, 83);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 50);
            this.CancelButton.TabIndex = 6;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(107, 28);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 49);
            this.OKButton.TabIndex = 7;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CPUEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(194, 139);
            this.ControlBox = false;
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SocketComboBox);
            this.Controls.Add(this.FrequencyNumericUpDown);
            this.Controls.Add(this.IDNumericUpDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "CPUEditForm";
            this.ShowIcon = false;
            this.Text = "CPUEditForm";
            this.Load += new System.EventHandler(this.CPUEditForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.IDNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FrequencyNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown IDNumericUpDown;
        private System.Windows.Forms.NumericUpDown FrequencyNumericUpDown;
        private System.Windows.Forms.ComboBox SocketComboBox;
        private new System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button OKButton;
    }
}