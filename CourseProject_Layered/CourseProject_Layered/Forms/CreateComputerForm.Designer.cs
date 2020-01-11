namespace CourseProject_Layered
{
    partial class CreateComputerForm
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
            this.OKButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.InventoryNumberTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(12, 66);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 25);
            this.OKButton.TabIndex = 0;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(106, 66);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 25);
            this.CancelButton.TabIndex = 1;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Inventory number";
            // 
            // InventoryNumberTextBox
            // 
            this.InventoryNumberTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.InventoryNumberTextBox.Location = new System.Drawing.Point(13, 34);
            this.InventoryNumberTextBox.MaxLength = 10;
            this.InventoryNumberTextBox.Name = "InventoryNumberTextBox";
            this.InventoryNumberTextBox.Size = new System.Drawing.Size(164, 20);
            this.InventoryNumberTextBox.TabIndex = 3;
            // 
            // CreateComputerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(193, 101);
            this.ControlBox = false;
            this.Controls.Add(this.InventoryNumberTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OKButton);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateComputerForm";
            this.ShowIcon = false;
            this.Text = "Create computer";
            this.Load += new System.EventHandler(this.CreateComputerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OKButton;
        private new System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox InventoryNumberTextBox;
    }
}