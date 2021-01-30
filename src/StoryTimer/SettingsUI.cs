using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Windows.Forms;


namespace StoryTimer
{
    public partial class SettingsUI : Form
    {
        private AppOptions _appOptions;
        private SettingsManager _settingsManager;

        public SettingsUI(IOptionsMonitor<AppOptions> appOptions = null)
        {
            InitializeComponent();
            
            _appOptions = appOptions?.CurrentValue ?? Program.Services.GetService<AppOptions>();
            _settingsManager = new SettingsManager();
            ShowSettings();
        }

        private void ShowSettings()
        {
            textBoxCurrentTimesFile.Text = _appOptions.SaveCurrentTimesFilePath;
            textBoxPreviousTimesFile.Text = _appOptions.SavePreviousTimesFilePath;
        }


        private void SaveAppOptions()
        {
            _appOptions.SaveCurrentTimesFilePath = textBoxCurrentTimesFile.Text;
            _appOptions.SavePreviousTimesFilePath = textBoxPreviousTimesFile.Text;
            _settingsManager.SaveAppOptions(_appOptions);
        }


        private void SetTimesFileFromDialog(Button button)
        {
            TextBox textBox = null;
            if ((string)button.Tag == "CurrentTimesFile")
            {
                textBox = textBoxCurrentTimesFile;
            }
            if ((string)button.Tag == "PreviousTimesFile")
            {
                textBox = textBoxPreviousTimesFile;
            }

            openFileDialog1.FileName = textBox.Text;
            var response = openFileDialog1.ShowDialog();
            if (response == DialogResult.OK)
            {
                textBox.Text = openFileDialog1.FileName;
                SaveAppOptions();
            }
        }

        private void SetTimesFileFromTextBox(TextBox textBox)
        {
            var newFile = textBox.Text;
            if (textBox.Name == nameof(textBoxCurrentTimesFile))
            {
                TryFileMove(_appOptions.SaveCurrentTimesFilePath, newFile);
            }
            if (textBox.Name == nameof(textBoxPreviousTimesFile))
            {
                TryFileMove(_appOptions.SavePreviousTimesFilePath, newFile);
            }
            SaveAppOptions();
        }

        private void TryFileMove(string oldFile, string newFile)
        {
            if (File.Exists(newFile)) { throw new Exception("Target file exists"); }
            if (oldFile != newFile)
            {
                File.Move(oldFile, newFile);
            }
        }



        private void buttonCurrentTimesFile_Click(object sender, EventArgs e)
        {
            SetTimesFileFromDialog((Button)sender);
        }

        private void buttonPreviousTimesFile_Click(object sender, EventArgs e)
        {
            SetTimesFileFromDialog((Button)sender);
        }


        private void textBoxCurrentTimesFile_Leave(object sender, EventArgs e)
        {
            try
            {
                SetTimesFileFromTextBox((TextBox)sender);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBoxPreviousTimesFile_Leave(object sender, EventArgs e)
        {
            try
            {
                SetTimesFileFromTextBox((TextBox)sender);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
