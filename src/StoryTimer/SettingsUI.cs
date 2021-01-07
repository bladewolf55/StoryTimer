using Microsoft.Extensions.Options;
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
    public partial class SettingsUI : Form
    {
        private AppOptions _appOptions;
        public SettingsUI(IOptions<AppOptions> appOptions)
        {
            InitializeComponent();
            _appOptions = appOptions.Value;
        }

        private void ShowSettings()
        {
            textBoxCurrentTimesFile.Text = _appOptions.SaveCurrentTimesFilePath;
            textBoxPreviousTimesFile.Text = _appOptions.SavePreviousTimesFilePath;
        }

        private void buttonCurrentTimesFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = textBoxCurrentTimesFile.Text;
            var response = openFileDialog1.ShowDialog();
            if (response == DialogResult.OK)
            {
                textBoxCurrentTimesFile.Text = openFileDialog1.FileName;
                _appOptions = new AppOptions(SaveCurrentTimesFilePath: textBoxCurrentTimesFile.Text);

            }
        }
    }
}
