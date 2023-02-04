using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoryTimer
{
    public partial class SnippetSelector : Form
    {
        public string Snippet { get; set; } = String.Empty;
        public bool SnippetSelected { get; set; }

        public SnippetSelector()
        {
            InitializeComponent();
        }

        private void listBoxSnippets_KeyDown(object sender, KeyEventArgs e)
        {
            // default
            SnippetSelected = false;
            if (e.KeyCode == Keys.Enter)
            {
                SetSnippet();
                SnippetSelected = true;
                this.Close();
            }
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void SetSnippet()
        {
            Snippet = listBoxSnippets.SelectedValue.ToString();
        }

        public void SetSnippetList(string[] snippets)
        {
            listBoxSnippets.DataSource = snippets;
        }

    }
}
