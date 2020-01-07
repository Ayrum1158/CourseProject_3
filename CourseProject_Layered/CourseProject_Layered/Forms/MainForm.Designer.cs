namespace CourseProject_Layered
{
    partial class ComputerPartsForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainDGV = new System.Windows.Forms.DataGridView();
            this.TopLable = new System.Windows.Forms.Label();
            this.CloseLable = new System.Windows.Forms.Label();
            this.InventoryNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Motherboard_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RAM_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Peripherals_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CPU_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Changelog_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoadDBButton = new System.Windows.Forms.Button();
            this.CreateComputerButton = new System.Windows.Forms.Button();
            this.RemoveComputerButton = new System.Windows.Forms.Button();
            this.EditMotherboardButton = new System.Windows.Forms.Button();
            this.EditRAMButton = new System.Windows.Forms.Button();
            this.EditCPUButton = new System.Windows.Forms.Button();
            this.EditPeripheralsButton = new System.Windows.Forms.Button();
            this.ShowChangelogButton = new System.Windows.Forms.Button();
            this.PeripheralsListBox = new System.Windows.Forms.ListBox();
            this.ChangelogListBox = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.MainDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // MainDGV
            // 
            this.MainDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.MainDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MainDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.InventoryNumber,
            this.Motherboard_id,
            this.RAM_id,
            this.Peripherals_id,
            this.CPU_id,
            this.Changelog_id});
            this.MainDGV.Location = new System.Drawing.Point(3, 42);
            this.MainDGV.MultiSelect = false;
            this.MainDGV.Name = "MainDGV";
            this.MainDGV.Size = new System.Drawing.Size(483, 307);
            this.MainDGV.TabIndex = 0;
            // 
            // TopLable
            // 
            this.TopLable.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.TopLable.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TopLable.ForeColor = System.Drawing.SystemColors.Info;
            this.TopLable.Location = new System.Drawing.Point(-1, -1);
            this.TopLable.Name = "TopLable";
            this.TopLable.Size = new System.Drawing.Size(890, 40);
            this.TopLable.TabIndex = 1;
            this.TopLable.Text = "Computer Parts Course Project";
            this.TopLable.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TopLable_MouseDown);
            // 
            // CloseLable
            // 
            this.CloseLable.BackColor = System.Drawing.Color.OrangeRed;
            this.CloseLable.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CloseLable.Location = new System.Drawing.Point(846, -1);
            this.CloseLable.Name = "CloseLable";
            this.CloseLable.Size = new System.Drawing.Size(43, 40);
            this.CloseLable.TabIndex = 2;
            this.CloseLable.Text = "X";
            this.CloseLable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CloseLable.Click += new System.EventHandler(this.CloseLabel_Click);
            // 
            // InventoryNumber
            // 
            this.InventoryNumber.HeaderText = "Inventory Number";
            this.InventoryNumber.Name = "InventoryNumber";
            // 
            // Motherboard_id
            // 
            this.Motherboard_id.HeaderText = "Motherboard id";
            this.Motherboard_id.Name = "Motherboard_id";
            // 
            // RAM_id
            // 
            this.RAM_id.HeaderText = "RAM id";
            this.RAM_id.Name = "RAM_id";
            // 
            // Peripherals_id
            // 
            this.Peripherals_id.HeaderText = "Peripherals id";
            this.Peripherals_id.Name = "Peripherals_id";
            // 
            // CPU_id
            // 
            this.CPU_id.HeaderText = "CPU id";
            this.CPU_id.Name = "CPU_id";
            // 
            // Changelog_id
            // 
            this.Changelog_id.HeaderText = "Changelog id";
            this.Changelog_id.Name = "Changelog_id";
            // 
            // LoadDBButton
            // 
            this.LoadDBButton.Location = new System.Drawing.Point(3, 355);
            this.LoadDBButton.Name = "LoadDBButton";
            this.LoadDBButton.Size = new System.Drawing.Size(107, 41);
            this.LoadDBButton.TabIndex = 3;
            this.LoadDBButton.Text = "Load DB";
            this.LoadDBButton.UseVisualStyleBackColor = true;
            // 
            // CreateComputerButton
            // 
            this.CreateComputerButton.Location = new System.Drawing.Point(492, 43);
            this.CreateComputerButton.Name = "CreateComputerButton";
            this.CreateComputerButton.Size = new System.Drawing.Size(98, 48);
            this.CreateComputerButton.TabIndex = 4;
            this.CreateComputerButton.Text = "Create computer";
            this.CreateComputerButton.UseVisualStyleBackColor = true;
            // 
            // RemoveComputerButton
            // 
            this.RemoveComputerButton.Location = new System.Drawing.Point(492, 86);
            this.RemoveComputerButton.Name = "RemoveComputerButton";
            this.RemoveComputerButton.Size = new System.Drawing.Size(98, 48);
            this.RemoveComputerButton.TabIndex = 5;
            this.RemoveComputerButton.Text = "Remove computer";
            this.RemoveComputerButton.UseVisualStyleBackColor = true;
            // 
            // EditMotherboardButton
            // 
            this.EditMotherboardButton.Location = new System.Drawing.Point(492, 129);
            this.EditMotherboardButton.Name = "EditMotherboardButton";
            this.EditMotherboardButton.Size = new System.Drawing.Size(98, 48);
            this.EditMotherboardButton.TabIndex = 6;
            this.EditMotherboardButton.Text = "Edit Motherboard";
            this.EditMotherboardButton.UseVisualStyleBackColor = true;
            // 
            // EditRAMButton
            // 
            this.EditRAMButton.Location = new System.Drawing.Point(492, 172);
            this.EditRAMButton.Name = "EditRAMButton";
            this.EditRAMButton.Size = new System.Drawing.Size(98, 48);
            this.EditRAMButton.TabIndex = 7;
            this.EditRAMButton.Text = "Edit RAM";
            this.EditRAMButton.UseVisualStyleBackColor = true;
            // 
            // EditCPUButton
            // 
            this.EditCPUButton.Location = new System.Drawing.Point(492, 215);
            this.EditCPUButton.Name = "EditCPUButton";
            this.EditCPUButton.Size = new System.Drawing.Size(98, 48);
            this.EditCPUButton.TabIndex = 8;
            this.EditCPUButton.Text = "Edit CPU";
            this.EditCPUButton.UseVisualStyleBackColor = true;
            // 
            // EditPeripheralsButton
            // 
            this.EditPeripheralsButton.Location = new System.Drawing.Point(492, 258);
            this.EditPeripheralsButton.Name = "EditPeripheralsButton";
            this.EditPeripheralsButton.Size = new System.Drawing.Size(98, 48);
            this.EditPeripheralsButton.TabIndex = 9;
            this.EditPeripheralsButton.Text = "Edit peripherals";
            this.EditPeripheralsButton.UseVisualStyleBackColor = true;
            // 
            // ShowChangelogButton
            // 
            this.ShowChangelogButton.Location = new System.Drawing.Point(492, 301);
            this.ShowChangelogButton.Name = "ShowChangelogButton";
            this.ShowChangelogButton.Size = new System.Drawing.Size(98, 48);
            this.ShowChangelogButton.TabIndex = 10;
            this.ShowChangelogButton.Text = "Show changelog for selected";
            this.ShowChangelogButton.UseVisualStyleBackColor = true;
            // 
            // PeripheralsListBox
            // 
            this.PeripheralsListBox.FormattingEnabled = true;
            this.PeripheralsListBox.Location = new System.Drawing.Point(596, 43);
            this.PeripheralsListBox.Name = "PeripheralsListBox";
            this.PeripheralsListBox.Size = new System.Drawing.Size(288, 147);
            this.PeripheralsListBox.TabIndex = 11;
            // 
            // ChangelogListBox
            // 
            this.ChangelogListBox.FormattingEnabled = true;
            this.ChangelogListBox.Location = new System.Drawing.Point(596, 202);
            this.ChangelogListBox.Name = "ChangelogListBox";
            this.ChangelogListBox.Size = new System.Drawing.Size(288, 147);
            this.ChangelogListBox.TabIndex = 12;
            // 
            // ComputerPartsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(889, 400);
            this.Controls.Add(this.ChangelogListBox);
            this.Controls.Add(this.PeripheralsListBox);
            this.Controls.Add(this.ShowChangelogButton);
            this.Controls.Add(this.EditPeripheralsButton);
            this.Controls.Add(this.EditCPUButton);
            this.Controls.Add(this.EditRAMButton);
            this.Controls.Add(this.EditMotherboardButton);
            this.Controls.Add(this.RemoveComputerButton);
            this.Controls.Add(this.CreateComputerButton);
            this.Controls.Add(this.LoadDBButton);
            this.Controls.Add(this.CloseLable);
            this.Controls.Add(this.TopLable);
            this.Controls.Add(this.MainDGV);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ComputerPartsForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Computer Parts Course Project";
            this.Load += new System.EventHandler(this.ComputerPartsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MainDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView MainDGV;
        private System.Windows.Forms.Label TopLable;
        private System.Windows.Forms.Label CloseLable;
        private System.Windows.Forms.DataGridViewTextBoxColumn InventoryNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Motherboard_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn RAM_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Peripherals_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn CPU_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Changelog_id;
        private System.Windows.Forms.Button LoadDBButton;
        private System.Windows.Forms.Button CreateComputerButton;
        private System.Windows.Forms.Button RemoveComputerButton;
        private System.Windows.Forms.Button EditMotherboardButton;
        private System.Windows.Forms.Button EditRAMButton;
        private System.Windows.Forms.Button EditCPUButton;
        private System.Windows.Forms.Button EditPeripheralsButton;
        private System.Windows.Forms.Button ShowChangelogButton;
        private System.Windows.Forms.ListBox PeripheralsListBox;
        private System.Windows.Forms.ListBox ChangelogListBox;
    }
}

