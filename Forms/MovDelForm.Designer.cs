namespace IPTest3
{
    partial class MovDelForm
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
            this.MovDelListBox = new System.Windows.Forms.ListBox();
            this.continueButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.successLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // MovDelListBox
            // 
            this.MovDelListBox.FormattingEnabled = true;
            this.MovDelListBox.ItemHeight = 20;
            this.MovDelListBox.Location = new System.Drawing.Point(12, 47);
            this.MovDelListBox.Name = "MovDelListBox";
            this.MovDelListBox.Size = new System.Drawing.Size(282, 304);
            this.MovDelListBox.TabIndex = 0;
            // 
            // continueButton
            // 
            this.continueButton.Location = new System.Drawing.Point(12, 12);
            this.continueButton.Name = "continueButton";
            this.continueButton.Size = new System.Drawing.Size(111, 29);
            this.continueButton.TabIndex = 1;
            this.continueButton.Text = "Продолжить";
            this.continueButton.UseVisualStyleBackColor = true;
            this.continueButton.Click += new System.EventHandler(this.continueButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(129, 12);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(111, 29);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // successLabel
            // 
            this.successLabel.AutoSize = true;
            this.successLabel.Location = new System.Drawing.Point(457, 16);
            this.successLabel.Name = "successLabel";
            this.successLabel.Size = new System.Drawing.Size(0, 20);
            this.successLabel.TabIndex = 3;
            // 
            // MovDelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.successLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.continueButton);
            this.Controls.Add(this.MovDelListBox);
            this.Name = "MovDelForm";
            this.Text = "MovDelForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox MovDelListBox;
        private Button continueButton;
        private Button cancelButton;
        private Label successLabel;
    }
}