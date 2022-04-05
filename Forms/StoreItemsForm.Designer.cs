namespace IPTest3
{
    partial class StoreItemsForm
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
            this.movingButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.addNewItemButton = new System.Windows.Forms.Button();
            this.StoreItemsListBox = new System.Windows.Forms.ListBox();
            this.backButton = new System.Windows.Forms.Button();
            this.timeTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.getBalanceButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // movingButton
            // 
            this.movingButton.Location = new System.Drawing.Point(12, 12);
            this.movingButton.Name = "movingButton";
            this.movingButton.Size = new System.Drawing.Size(120, 29);
            this.movingButton.TabIndex = 1;
            this.movingButton.Text = "Переместить";
            this.movingButton.UseVisualStyleBackColor = true;
            this.movingButton.Click += new System.EventHandler(this.movingButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(264, 12);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(120, 29);
            this.deleteButton.TabIndex = 2;
            this.deleteButton.Text = "Удалить";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // addNewItemButton
            // 
            this.addNewItemButton.Location = new System.Drawing.Point(138, 12);
            this.addNewItemButton.Name = "addNewItemButton";
            this.addNewItemButton.Size = new System.Drawing.Size(120, 29);
            this.addNewItemButton.TabIndex = 3;
            this.addNewItemButton.Text = "Добавить";
            this.addNewItemButton.UseVisualStyleBackColor = true;
            this.addNewItemButton.Click += new System.EventHandler(this.addNewItemButton_Click);
            // 
            // StoreItemsListBox
            // 
            this.StoreItemsListBox.FormattingEnabled = true;
            this.StoreItemsListBox.ItemHeight = 20;
            this.StoreItemsListBox.Location = new System.Drawing.Point(12, 47);
            this.StoreItemsListBox.Name = "StoreItemsListBox";
            this.StoreItemsListBox.Size = new System.Drawing.Size(372, 364);
            this.StoreItemsListBox.TabIndex = 4;
            this.StoreItemsListBox.SelectedIndexChanged += new System.EventHandler(this.StoreItemsListBox_SelectedIndexChanged);
            this.StoreItemsListBox.SelectedValueChanged += new System.EventHandler(this.StoreItemsListBox_SelectedValueChanged);
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(390, 12);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(120, 29);
            this.backButton.TabIndex = 5;
            this.backButton.Text = "Назад";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // timeTextBox
            // 
            this.timeTextBox.Location = new System.Drawing.Point(388, 70);
            this.timeTextBox.Name = "timeTextBox";
            this.timeTextBox.Size = new System.Drawing.Size(178, 27);
            this.timeTextBox.TabIndex = 6;
            this.timeTextBox.Text = "01.01.2022 00:00:00";
            this.timeTextBox.TextChanged += new System.EventHandler(this.timeTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(390, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Время расчета остатков";
            // 
            // getBalanceButton
            // 
            this.getBalanceButton.Location = new System.Drawing.Point(390, 103);
            this.getBalanceButton.Name = "getBalanceButton";
            this.getBalanceButton.Size = new System.Drawing.Size(120, 29);
            this.getBalanceButton.TabIndex = 8;
            this.getBalanceButton.Text = "Рассчитать";
            this.getBalanceButton.UseVisualStyleBackColor = true;
            this.getBalanceButton.Click += new System.EventHandler(this.getBalanceButton_Click);
            // 
            // StoreItemsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.getBalanceButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.timeTextBox);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.StoreItemsListBox);
            this.Controls.Add(this.addNewItemButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.movingButton);
            this.Name = "StoreItemsForm";
            this.Text = "StoreItemsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button movingButton;
        private Button deleteButton;
        private Button addNewItemButton;
        private ListBox StoreItemsListBox;
        private Button backButton;
        private TextBox timeTextBox;
        private Label label1;
        private Button getBalanceButton;
    }
}