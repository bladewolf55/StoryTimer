namespace StoryTimer
{
    partial class SnippetSelector
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
            listBoxSnippets = new System.Windows.Forms.ListBox();
            SuspendLayout();
            // 
            // listBoxSnippets
            // 
            listBoxSnippets.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            listBoxSnippets.FormattingEnabled = true;
            listBoxSnippets.ItemHeight = 15;
            listBoxSnippets.Location = new System.Drawing.Point(2, -1);
            listBoxSnippets.Name = "listBoxSnippets";
            listBoxSnippets.Size = new System.Drawing.Size(194, 154);
            listBoxSnippets.TabIndex = 0;
            listBoxSnippets.KeyDown += listBoxSnippets_KeyDown;
            // 
            // SnippetSelector
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(198, 160);
            ControlBox = false;
            Controls.Add(listBoxSnippets);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            Name = "SnippetSelector";
            Text = "Snippet Selector";
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.ListBox listBoxSnippets;
    }
}