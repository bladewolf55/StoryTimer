namespace StoryTimer
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel = new System.Windows.Forms.Panel();
            this.richTextBoxElapsedTime = new System.Windows.Forms.RichTextBox();
            this.buttonReset = new System.Windows.Forms.Button();
            this.buttonStartPause = new System.Windows.Forms.Button();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.textBoxNew = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.buttonResetAll = new System.Windows.Forms.Button();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel.Controls.Add(this.richTextBoxElapsedTime);
            this.panel.Controls.Add(this.buttonReset);
            this.panel.Controls.Add(this.buttonStartPause);
            this.panel.Controls.Add(this.textBoxTitle);
            this.panel.Location = new System.Drawing.Point(9, 63);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(182, 59);
            this.panel.TabIndex = 0;
            // 
            // richTextBoxElapsedTime
            // 
            this.richTextBoxElapsedTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.richTextBoxElapsedTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxElapsedTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxElapsedTime.ForeColor = System.Drawing.Color.Orange;
            this.richTextBoxElapsedTime.Location = new System.Drawing.Point(94, 28);
            this.richTextBoxElapsedTime.Name = "richTextBoxElapsedTime";
            this.richTextBoxElapsedTime.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBoxElapsedTime.Size = new System.Drawing.Size(80, 28);
            this.richTextBoxElapsedTime.TabIndex = 4;
            this.richTextBoxElapsedTime.Text = " 0:00:00";
            // 
            // buttonReset
            // 
            this.buttonReset.BackColor = System.Drawing.SystemColors.Control;
            this.buttonReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReset.Location = new System.Drawing.Point(46, 28);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(42, 28);
            this.buttonReset.TabIndex = 3;
            this.buttonReset.Text = "R";
            this.buttonReset.UseVisualStyleBackColor = false;
            // 
            // buttonStartPause
            // 
            this.buttonStartPause.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonStartPause.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStartPause.Location = new System.Drawing.Point(4, 28);
            this.buttonStartPause.Name = "buttonStartPause";
            this.buttonStartPause.Size = new System.Drawing.Size(43, 28);
            this.buttonStartPause.TabIndex = 2;
            this.buttonStartPause.Text = ">  | |";
            this.buttonStartPause.UseVisualStyleBackColor = false;
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTitle.Location = new System.Drawing.Point(4, 3);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(170, 20);
            this.textBoxTitle.TabIndex = 1;
            // 
            // textBoxNew
            // 
            this.textBoxNew.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxNew.Location = new System.Drawing.Point(13, 38);
            this.textBoxNew.Name = "textBoxNew";
            this.textBoxNew.Size = new System.Drawing.Size(170, 20);
            this.textBoxNew.TabIndex = 0;
            this.textBoxNew.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxNew_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Story Timer";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(178, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Enter a title and <Enter>";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox1.Location = new System.Drawing.Point(112, 5);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(71, 17);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "Exclusive";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // buttonResetAll
            // 
            this.buttonResetAll.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonResetAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonResetAll.Location = new System.Drawing.Point(132, 20);
            this.buttonResetAll.Name = "buttonResetAll";
            this.buttonResetAll.Size = new System.Drawing.Size(50, 17);
            this.buttonResetAll.TabIndex = 4;
            this.buttonResetAll.Text = "Reset";
            this.buttonResetAll.UseVisualStyleBackColor = true;
            this.buttonResetAll.Click += new System.EventHandler(this.ButtonResetAll_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(197, 128);
            this.Controls.Add(this.buttonResetAll);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxNew);
            this.Controls.Add(this.panel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.RichTextBox richTextBoxElapsedTime;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Button buttonStartPause;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.TextBox textBoxNew;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button buttonResetAll;
    }
}

