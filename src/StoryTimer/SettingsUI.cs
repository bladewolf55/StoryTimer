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
        IOptionsMonitor<AppOptions> _appOptionsMonitor = null;

        public bool CurrentTimesFileChanged { get; set; }

        public SettingsUI(IOptionsMonitor<AppOptions> appOptionsMonitor = null)
        {
            InitializeComponent();
            _appOptionsMonitor = appOptionsMonitor;
            _settingsManager = new SettingsManager();
        }

        private void ShowSettings()
        {
            _appOptions = _appOptionsMonitor?.CurrentValue ?? Program.Services.GetService<AppOptions>();
            textBoxCurrentTimesFile.Text = _appOptions.SaveCurrentTimesFilePath;
            textBoxPreviousTimesFile.Text = _appOptions.SavePreviousTimesFilePath;
            textBoxSnippetsFile.Text = _appOptions.SaveSnippetsFilePath;
            if (File.Exists(_appOptions.SaveSnippetsFilePath))
            {
                textBoxSnippets.Text = File.ReadAllText(_appOptions.SaveSnippetsFilePath);
            }
            EnableDisableSnippetsEdit();
        }

        private void EnableDisableSnippetsEdit()
        {
            textBoxSnippets.Enabled = File.Exists(_appOptions.SaveSnippetsFilePath);
        }

        private void SaveAppOptions()
        {
            SaveSnippets();
            CurrentTimesFileChanged = _appOptions.SaveCurrentTimesFilePath != textBoxCurrentTimesFile.Text;
            _appOptions.SaveCurrentTimesFilePath = textBoxCurrentTimesFile.Text;
            _appOptions.SavePreviousTimesFilePath = textBoxPreviousTimesFile.Text;
            _appOptions.SaveSnippetsFilePath = textBoxSnippetsFile.Text;
            _settingsManager.SaveAppOptions(_appOptions);
            EnableDisableSnippetsEdit();
        }

        private void SaveSnippets()
        {
            var filePath = _appOptions.SaveSnippetsFilePath;
            var contents = textBoxSnippets.Text;
            File.WriteAllText(filePath, contents);
        }

        private void SetFileFromDialog(Button button)
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
            if ((string)button.Tag == "SnippetsFile")
            {
                textBox = textBoxSnippetsFile;
            }

            openFileDialog1.FileName = textBox.Text;
            var response = openFileDialog1.ShowDialog();
            if (response == DialogResult.OK)
            {
                textBox.Text = openFileDialog1.FileName;
            }
        }

        private void buttonCurrentTimesFile_Click(object sender, EventArgs e)
        {
            SetFileFromDialog((Button)sender);
        }

        private void buttonPreviousTimesFile_Click(object sender, EventArgs e)
        {
            SetFileFromDialog((Button)sender);
        }

        private void buttonSnippetsFile_Click(object sender, EventArgs e)
        {
            SetFileFromDialog((Button)sender);
        }

        private void textBoxSnippets_TextChanged(object sender, EventArgs e)
        {
            SaveSnippets();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveAppOptions();
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void LoadCurrentSettings()
        {
            _appOptions = Program.Services.GetService<AppOptions>();
            ShowSettings();
        }

        private void SettingsUI_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
                LoadCurrentSettings();
        }
    }
}
