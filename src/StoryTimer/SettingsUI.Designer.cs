
namespace StoryTimer
{
    partial class SettingsUI
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
            this.textBoxCurrentTimesFile = new System.Windows.Forms.TextBox();
            this.textBoxPreviousTimesFile = new System.Windows.Forms.TextBox();
            this.buttonCurrentTimesFile = new System.Windows.Forms.Button();
            this.buttonPreviousTimesFile = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Current Times File";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Previous Times File";
            // 
            // textBoxCurrentTimesFile
            // 
            this.textBoxCurrentTimesFile.Location = new System.Drawing.Point(147, 10);
            this.textBoxCurrentTimesFile.Name = "textBoxCurrentTimesFile";
            this.textBoxCurrentTimesFile.Size = new System.Drawing.Size(319, 23);
            this.textBoxCurrentTimesFile.TabIndex = 2;
            // 
            // textBoxPreviousTimesFile
            // 
            this.textBoxPreviousTimesFile.Location = new System.Drawing.Point(147, 36);
            this.textBoxPreviousTimesFile.Name = "textBoxPreviousTimesFile";
            this.textBoxPreviousTimesFile.Size = new System.Drawing.Size(319, 23);
            this.textBoxPreviousTimesFile.TabIndex = 3;
            // 
            // buttonCurrentTimesFile
            // 
            this.buttonCurrentTimesFile.Location = new System.Drawing.Point(472, 10);
            this.buttonCurrentTimesFile.Name = "buttonCurrentTimesFile";
            this.buttonCurrentTimesFile.Size = new System.Drawing.Size(25, 23);
            this.buttonCurrentTimesFile.TabIndex = 4;
            this.buttonCurrentTimesFile.Text = "...";
            this.buttonCurrentTimesFile.UseVisualStyleBackColor = true;
            this.buttonCurrentTimesFile.Click += new System.EventHandler(this.buttonCurrentTimesFile_Click);
            // 
            // buttonPreviousTimesFile
            // 
            this.buttonPreviousTimesFile.Location = new System.Drawing.Point(472, 36);
            this.buttonPreviousTimesFile.Name = "buttonPreviousTimesFile";
            this.buttonPreviousTimesFile.Size = new System.Drawing.Size(25, 23);
            this.buttonPreviousTimesFile.TabIndex = 5;
            this.buttonPreviousTimesFile.Text = "...";
            this.buttonPreviousTimesFile.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // SettingsUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 75);
            this.Controls.Add(this.buttonPreviousTimesFile);
            this.Controls.Add(this.buttonCurrentTimesFile);
            this.Controls.Add(this.textBoxPreviousTimesFile);
            this.Controls.Add(this.textBoxCurrentTimesFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SettingsUI";
            this.Text = "Story Timer Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxCurrentTimesFile;
        private System.Windows.Forms.TextBox textBoxPreviousTimesFile;
        private System.Windows.Forms.Button buttonCurrentTimesFile;
        private System.Windows.Forms.Button buttonPreviousTimesFile;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}