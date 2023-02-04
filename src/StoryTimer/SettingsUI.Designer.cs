
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
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            textBoxCurrentTimesFile = new System.Windows.Forms.TextBox();
            textBoxPreviousTimesFile = new System.Windows.Forms.TextBox();
            buttonCurrentTimesFile = new System.Windows.Forms.Button();
            buttonPreviousTimesFile = new System.Windows.Forms.Button();
            folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            label3 = new System.Windows.Forms.Label();
            textBoxSnippets = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            textBoxSnippetsFile = new System.Windows.Forms.TextBox();
            buttonSnippetsFile = new System.Windows.Forms.Button();
            buttonSave = new System.Windows.Forms.Button();
            buttonCancel = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(13, 13);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(102, 15);
            label1.TabIndex = 0;
            label1.Text = "Current Times File";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(13, 39);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(107, 15);
            label2.TabIndex = 1;
            label2.Text = "Previous Times File";
            // 
            // textBoxCurrentTimesFile
            // 
            textBoxCurrentTimesFile.Location = new System.Drawing.Point(147, 10);
            textBoxCurrentTimesFile.Name = "textBoxCurrentTimesFile";
            textBoxCurrentTimesFile.Size = new System.Drawing.Size(319, 23);
            textBoxCurrentTimesFile.TabIndex = 2;
            // 
            // textBoxPreviousTimesFile
            // 
            textBoxPreviousTimesFile.Location = new System.Drawing.Point(147, 36);
            textBoxPreviousTimesFile.Name = "textBoxPreviousTimesFile";
            textBoxPreviousTimesFile.Size = new System.Drawing.Size(319, 23);
            textBoxPreviousTimesFile.TabIndex = 3;
            // 
            // buttonCurrentTimesFile
            // 
            buttonCurrentTimesFile.Location = new System.Drawing.Point(472, 10);
            buttonCurrentTimesFile.Name = "buttonCurrentTimesFile";
            buttonCurrentTimesFile.Size = new System.Drawing.Size(25, 23);
            buttonCurrentTimesFile.TabIndex = 4;
            buttonCurrentTimesFile.Tag = "CurrentTimesFile";
            buttonCurrentTimesFile.Text = "...";
            buttonCurrentTimesFile.UseVisualStyleBackColor = true;
            buttonCurrentTimesFile.Click += buttonCurrentTimesFile_Click;
            // 
            // buttonPreviousTimesFile
            // 
            buttonPreviousTimesFile.Location = new System.Drawing.Point(472, 36);
            buttonPreviousTimesFile.Name = "buttonPreviousTimesFile";
            buttonPreviousTimesFile.Size = new System.Drawing.Size(25, 23);
            buttonPreviousTimesFile.TabIndex = 5;
            buttonPreviousTimesFile.Tag = "PreviousTimesFile";
            buttonPreviousTimesFile.Text = "...";
            buttonPreviousTimesFile.UseVisualStyleBackColor = true;
            buttonPreviousTimesFile.Click += buttonPreviousTimesFile_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(13, 68);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(73, 15);
            label3.TabIndex = 6;
            label3.Text = "Snippets File";
            // 
            // textBoxSnippets
            // 
            textBoxSnippets.Location = new System.Drawing.Point(147, 94);
            textBoxSnippets.Multiline = true;
            textBoxSnippets.Name = "textBoxSnippets";
            textBoxSnippets.Size = new System.Drawing.Size(319, 105);
            textBoxSnippets.TabIndex = 7;
            textBoxSnippets.TextChanged += textBoxSnippets_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(12, 97);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(118, 75);
            label4.TabIndex = 8;
            label4.Text = "Type each snippet \r\non its own line.\r\n\r\nInsert snippets using \r\nCtrl+I.";
            // 
            // textBoxSnippetsFile
            // 
            textBoxSnippetsFile.Location = new System.Drawing.Point(147, 65);
            textBoxSnippetsFile.Name = "textBoxSnippetsFile";
            textBoxSnippetsFile.Size = new System.Drawing.Size(319, 23);
            textBoxSnippetsFile.TabIndex = 9;
            // 
            // buttonSnippetsFile
            // 
            buttonSnippetsFile.Location = new System.Drawing.Point(472, 64);
            buttonSnippetsFile.Name = "buttonSnippetsFile";
            buttonSnippetsFile.Size = new System.Drawing.Size(25, 23);
            buttonSnippetsFile.TabIndex = 10;
            buttonSnippetsFile.Tag = "SnippetsFile";
            buttonSnippetsFile.Text = "...";
            buttonSnippetsFile.UseVisualStyleBackColor = true;
            buttonSnippetsFile.Click += buttonSnippetsFile_Click;
            // 
            // buttonSave
            // 
            buttonSave.Location = new System.Drawing.Point(190, 215);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new System.Drawing.Size(75, 23);
            buttonSave.TabIndex = 11;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new System.Drawing.Point(271, 215);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new System.Drawing.Size(75, 23);
            buttonCancel.TabIndex = 12;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // SettingsUI
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(519, 250);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Controls.Add(buttonSnippetsFile);
            Controls.Add(textBoxSnippetsFile);
            Controls.Add(label4);
            Controls.Add(textBoxSnippets);
            Controls.Add(label3);
            Controls.Add(buttonPreviousTimesFile);
            Controls.Add(buttonCurrentTimesFile);
            Controls.Add(textBoxPreviousTimesFile);
            Controls.Add(textBoxCurrentTimesFile);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "SettingsUI";
            Text = "Story Timer Settings";
            VisibleChanged += SettingsUI_VisibleChanged;
            ResumeLayout(false);
            PerformLayout();
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxSnippetsFile;
        private System.Windows.Forms.Button buttonSnippetsFile;
        private System.Windows.Forms.TextBox textBoxSnippets;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
    }
}