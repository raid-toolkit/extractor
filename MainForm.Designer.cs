namespace RaidExtractor
{
    partial class MainForm
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
			this.SaveButton = new System.Windows.Forms.Button();
			this.SaveJSONDialog = new System.Windows.Forms.SaveFileDialog();
			this.SaveZipFile = new System.Windows.Forms.CheckBox();
			this.AccountsListBox = new System.Windows.Forms.CheckedListBox();
			this.SuspendLayout();
			// 
			// SaveButton
			// 
			this.SaveButton.Location = new System.Drawing.Point(221, 14);
			this.SaveButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.SaveButton.Name = "SaveButton";
			this.SaveButton.Size = new System.Drawing.Size(88, 27);
			this.SaveButton.TabIndex = 0;
			this.SaveButton.Text = "Save JSON";
			this.SaveButton.UseVisualStyleBackColor = true;
			this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
			// 
			// SaveJSONDialog
			// 
			this.SaveJSONDialog.DefaultExt = "json";
			this.SaveJSONDialog.FileName = "artifacts.json";
			this.SaveJSONDialog.Filter = "JSON files|*.json";
			this.SaveJSONDialog.Title = "Save JSON";
			// 
			// SaveZipFile
			// 
			this.SaveZipFile.AutoSize = true;
			this.SaveZipFile.Location = new System.Drawing.Point(221, 61);
			this.SaveZipFile.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.SaveZipFile.Name = "SaveZipFile";
			this.SaveZipFile.Size = new System.Drawing.Size(259, 19);
			this.SaveZipFile.TabIndex = 2;
			this.SaveZipFile.Text = "Also save a Zipped Copy of the artifacts.json";
			this.SaveZipFile.UseVisualStyleBackColor = true;
			// 
			// AccountsListBox
			// 
			this.AccountsListBox.FormattingEnabled = true;
			this.AccountsListBox.Location = new System.Drawing.Point(12, 14);
			this.AccountsListBox.Name = "AccountsListBox";
			this.AccountsListBox.Size = new System.Drawing.Size(178, 94);
			this.AccountsListBox.TabIndex = 3;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(506, 151);
			this.Controls.Add(this.AccountsListBox);
			this.Controls.Add(this.SaveZipFile);
			this.Controls.Add(this.SaveButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.Name = "MainForm";
			this.Text = "Raid Extractor";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.SaveFileDialog SaveJSONDialog;
        private System.Windows.Forms.CheckBox SaveZipFile;
		private System.Windows.Forms.CheckedListBox AccountsListBox;
	}
}
