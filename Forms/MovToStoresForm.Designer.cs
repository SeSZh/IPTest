namespace IPTest3
{
    partial class MovToStoresForm
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
            this.StoresListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.successLabel = new System.Windows.Forms.Label();
            this.backButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StoresListBox
            // 
            this.StoresListBox.FormattingEnabled = true;
            this.StoresListBox.ItemHeight = 20;
            this.StoresListBox.Location = new System.Drawing.Point(12, 40);
            this.StoresListBox.Name = "StoresListBox";
            this.StoresListBox.Size = new System.Drawing.Size(285, 384);
            this.StoresListBox.TabIndex = 0;
            this.StoresListBox.SelectedIndexChanged += new System.EventHandler(this.StoresListBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Выбрать конечный склад";
            // 
            // successLabel
            // 
            this.successLabel.AutoSize = true;
            this.successLabel.Location = new System.Drawing.Point(446, 37);
            this.successLabel.Name = "successLabel";
            this.successLabel.Size = new System.Drawing.Size(0, 20);
            this.successLabel.TabIndex = 2;
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(203, 5);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(94, 29);
            this.backButton.TabIndex = 3;
            this.backButton.Text = "Назад";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // MovToStoresForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.successLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StoresListBox);
            this.Name = "MovToStoresForm";
            this.Text = "MovToStoresPage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox StoresListBox;
        private Label label1;
        private Label successLabel;
        private Button backButton;
    }
}