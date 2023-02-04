
namespace StoryTimer
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            label1 = new System.Windows.Forms.Label();
            checkBox1 = new System.Windows.Forms.CheckBox();
            label2 = new System.Windows.Forms.Label();
            buttonResetAll = new System.Windows.Forms.Button();
            textBoxNew = new System.Windows.Forms.TextBox();
            panel = new System.Windows.Forms.Panel();
            richTextBoxElapsedTime = new System.Windows.Forms.RichTextBox();
            buttonReset = new System.Windows.Forms.Button();
            buttonStartPause = new System.Windows.Forms.Button();
            textBoxTitle = new System.Windows.Forms.TextBox();
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            toolTip1 = new System.Windows.Forms.ToolTip(components);
            panel.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(5, 3);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(89, 19);
            label1.TabIndex = 0;
            label1.Text = "Story Timer";
            // 
            // checkBox1
            // 
            checkBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            checkBox1.AutoSize = true;
            checkBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            checkBox1.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            checkBox1.Location = new System.Drawing.Point(122, 3);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new System.Drawing.Size(71, 17);
            checkBox1.TabIndex = 1;
            checkBox1.Text = "Exclusive";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(6, 27);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(135, 15);
            label2.TabIndex = 2;
            label2.Text = "Enter a title and <Enter>";
            // 
            // buttonResetAll
            // 
            buttonResetAll.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            buttonResetAll.FlatStyle = System.Windows.Forms.FlatStyle.System;
            buttonResetAll.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            buttonResetAll.Location = new System.Drawing.Point(148, 23);
            buttonResetAll.Name = "buttonResetAll";
            buttonResetAll.Size = new System.Drawing.Size(45, 18);
            buttonResetAll.TabIndex = 3;
            buttonResetAll.Text = "Reset";
            buttonResetAll.UseVisualStyleBackColor = true;
            buttonResetAll.Click += ButtonResetAll_Click;
            // 
            // textBoxNew
            // 
            textBoxNew.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            textBoxNew.Location = new System.Drawing.Point(6, 45);
            textBoxNew.Name = "textBoxNew";
            textBoxNew.Size = new System.Drawing.Size(185, 23);
            textBoxNew.TabIndex = 4;
            textBoxNew.KeyDown += TextBoxNew_KeyDown;
            // 
            // panel
            // 
            panel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panel.Controls.Add(richTextBoxElapsedTime);
            panel.Controls.Add(buttonReset);
            panel.Controls.Add(buttonStartPause);
            panel.Controls.Add(textBoxTitle);
            panel.Location = new System.Drawing.Point(1, 76);
            panel.Name = "panel";
            panel.Size = new System.Drawing.Size(196, 60);
            panel.TabIndex = 5;
            // 
            // richTextBoxElapsedTime
            // 
            richTextBoxElapsedTime.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            richTextBoxElapsedTime.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            richTextBoxElapsedTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            richTextBoxElapsedTime.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            richTextBoxElapsedTime.ForeColor = System.Drawing.Color.Orange;
            richTextBoxElapsedTime.Location = new System.Drawing.Point(116, 29);
            richTextBoxElapsedTime.Multiline = false;
            richTextBoxElapsedTime.Name = "richTextBoxElapsedTime";
            richTextBoxElapsedTime.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            richTextBoxElapsedTime.Size = new System.Drawing.Size(74, 30);
            richTextBoxElapsedTime.TabIndex = 8;
            richTextBoxElapsedTime.Text = " 0:00:00";
            // 
            // buttonReset
            // 
            buttonReset.Location = new System.Drawing.Point(50, 29);
            buttonReset.Name = "buttonReset";
            buttonReset.Size = new System.Drawing.Size(43, 30);
            buttonReset.TabIndex = 7;
            buttonReset.Text = "R";
            buttonReset.UseVisualStyleBackColor = true;
            // 
            // buttonStartPause
            // 
            buttonStartPause.Location = new System.Drawing.Point(5, 29);
            buttonStartPause.Name = "buttonStartPause";
            buttonStartPause.Size = new System.Drawing.Size(43, 30);
            buttonStartPause.TabIndex = 6;
            buttonStartPause.Text = "> | |";
            buttonStartPause.UseVisualStyleBackColor = true;
            // 
            // textBoxTitle
            // 
            textBoxTitle.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            textBoxTitle.Location = new System.Drawing.Point(5, 0);
            textBoxTitle.Name = "textBoxTitle";
            textBoxTitle.Size = new System.Drawing.Size(185, 23);
            textBoxTitle.TabIndex = 5;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new System.Drawing.Point(0, 138);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new System.Drawing.Size(198, 22);
            statusStrip1.TabIndex = 6;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new System.Drawing.Size(38, 17);
            toolStripStatusLabel1.Text = "label1";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(198, 160);
            Controls.Add(statusStrip1);
            Controls.Add(panel);
            Controls.Add(textBoxNew);
            Controls.Add(buttonResetAll);
            Controls.Add(label2);
            Controls.Add(checkBox1);
            Controls.Add(label1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "MainForm";
            ShowIcon = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Load += MainForm_Load;
            ResizeEnd += MainForm_ResizeEnd;
            panel.ResumeLayout(false);
            panel.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonResetAll;
        private System.Windows.Forms.TextBox textBoxNew;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Button buttonStartPause;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.RichTextBox richTextBoxElapsedTime;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

