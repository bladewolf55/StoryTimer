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
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxTitle1 = new System.Windows.Forms.TextBox();
            this.textBoxNew = new System.Windows.Forms.TextBox();
            this.buttonStartPause1 = new System.Windows.Forms.Button();
            this.buttonReset1 = new System.Windows.Forms.Button();
            this.richTextBoxTime1 = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.richTextBoxTime1);
            this.panel1.Controls.Add(this.buttonReset1);
            this.panel1.Controls.Add(this.buttonStartPause1);
            this.panel1.Controls.Add(this.textBoxTitle1);
            this.panel1.Location = new System.Drawing.Point(12, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(182, 59);
            this.panel1.TabIndex = 0;
            // 
            // textBoxTitle1
            // 
            this.textBoxTitle1.Location = new System.Drawing.Point(4, 3);
            this.textBoxTitle1.Name = "textBoxTitle1";
            this.textBoxTitle1.Size = new System.Drawing.Size(170, 20);
            this.textBoxTitle1.TabIndex = 0;
            // 
            // textBoxNew
            // 
            this.textBoxNew.Location = new System.Drawing.Point(16, 8);
            this.textBoxNew.Name = "textBoxNew";
            this.textBoxNew.Size = new System.Drawing.Size(170, 20);
            this.textBoxNew.TabIndex = 1;
            this.textBoxNew.TextChanged += new System.EventHandler(this.TextBox2_TextChanged);
            // 
            // buttonStartPause1
            // 
            this.buttonStartPause1.Location = new System.Drawing.Point(4, 28);
            this.buttonStartPause1.Name = "buttonStartPause1";
            this.buttonStartPause1.Size = new System.Drawing.Size(38, 28);
            this.buttonStartPause1.TabIndex = 1;
            this.buttonStartPause1.Text = ">  | |";
            this.buttonStartPause1.UseVisualStyleBackColor = true;
            // 
            // buttonReset1
            // 
            this.buttonReset1.Location = new System.Drawing.Point(53, 28);
            this.buttonReset1.Name = "buttonReset1";
            this.buttonReset1.Size = new System.Drawing.Size(35, 28);
            this.buttonReset1.TabIndex = 3;
            this.buttonReset1.Text = "R";
            this.buttonReset1.UseVisualStyleBackColor = true;
            // 
            // richTextBoxTime1
            // 
            this.richTextBoxTime1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxTime1.Location = new System.Drawing.Point(100, 28);
            this.richTextBoxTime1.Name = "richTextBoxTime1";
            this.richTextBoxTime1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBoxTime1.Size = new System.Drawing.Size(74, 28);
            this.richTextBoxTime1.TabIndex = 4;
            this.richTextBoxTime1.Text = "0:00:00";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(203, 105);
            this.Controls.Add(this.textBoxNew);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Story Timer";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox richTextBoxTime1;
        private System.Windows.Forms.Button buttonReset1;
        private System.Windows.Forms.Button buttonStartPause1;
        private System.Windows.Forms.TextBox textBoxTitle1;
        private System.Windows.Forms.TextBox textBoxNew;
    }
}

