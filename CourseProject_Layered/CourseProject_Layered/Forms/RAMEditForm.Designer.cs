namespace CourseProject_Layered
{
    partial class RAMEditForm
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
            this.label5 = new System.Windows.Forms.Label();
            this.IDNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.VolumeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.StickCountNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.FrequencyNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.TypeComboBox = new System.Windows.Forms.ComboBox();
            this.CancelButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.IDNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StickCountNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FrequencyNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 14);
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
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Volume";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(94, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Type";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Stick count";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Frequency";
            // 
            // IDNumericUpDown
            // 
            this.IDNumericUpDown.Location = new System.Drawing.Point(11, 30);
            this.IDNumericUpDown.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.IDNumericUpDown.Name = "IDNumericUpDown";
            this.IDNumericUpDown.Size = new System.Drawing.Size(80, 20);
            this.IDNumericUpDown.TabIndex = 5;
            // 
            // VolumeNumericUpDown
            // 
            this.VolumeNumericUpDown.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.VolumeNumericUpDown.Location = new System.Drawing.Point(11, 69);
            this.VolumeNumericUpDown.Maximum = new decimal(new int[] {
            3200,
            0,
            0,
            0});
            this.VolumeNumericUpDown.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.VolumeNumericUpDown.Name = "VolumeNumericUpDown";
            this.VolumeNumericUpDown.Size = new System.Drawing.Size(80, 20);
            this.VolumeNumericUpDown.TabIndex = 6;
            this.VolumeNumericUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // StickCountNumericUpDown
            // 
            this.StickCountNumericUpDown.Location = new System.Drawing.Point(11, 108);
            this.StickCountNumericUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.StickCountNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.StickCountNumericUpDown.Name = "StickCountNumericUpDown";
            this.StickCountNumericUpDown.Size = new System.Drawing.Size(80, 20);
            this.StickCountNumericUpDown.TabIndex = 7;
            this.StickCountNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // FrequencyNumericUpDown
            // 
            this.FrequencyNumericUpDown.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.FrequencyNumericUpDown.Location = new System.Drawing.Point(11, 147);
            this.FrequencyNumericUpDown.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.FrequencyNumericUpDown.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.FrequencyNumericUpDown.Name = "FrequencyNumericUpDown";
            this.FrequencyNumericUpDown.Size = new System.Drawing.Size(80, 20);
            this.FrequencyNumericUpDown.TabIndex = 8;
            this.FrequencyNumericUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // TypeComboBox
            // 
            this.TypeComboBox.FormattingEnabled = true;
            this.TypeComboBox.Location = new System.Drawing.Point(97, 30);
            this.TypeComboBox.Name = "TypeComboBox";
            this.TypeComboBox.Size = new System.Drawing.Size(82, 21);
            this.TypeComboBox.TabIndex = 9;
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(104, 144);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 10;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(104, 110);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 11;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // RAMEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(190, 178);
            this.ControlBox = false;
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.TypeComboBox);
            this.Controls.Add(this.FrequencyNumericUpDown);
            this.Controls.Add(this.StickCountNumericUpDown);
            this.Controls.Add(this.VolumeNumericUpDown);
            this.Controls.Add(this.IDNumericUpDown);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "RAMEditForm";
            this.ShowIcon = false;
            this.Text = "RAM Edit";
            this.Load += new System.EventHandler(this.RAMEditForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.IDNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StickCountNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FrequencyNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown IDNumericUpDown;
        private System.Windows.Forms.NumericUpDown VolumeNumericUpDown;
        private System.Windows.Forms.NumericUpDown StickCountNumericUpDown;
        private System.Windows.Forms.NumericUpDown FrequencyNumericUpDown;
        private System.Windows.Forms.ComboBox TypeComboBox;
        private new System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button OKButton;
    }
}