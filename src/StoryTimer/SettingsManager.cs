using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows.Forms;

namespace StoryTimer
{
    public class SettingsManager
    {
        //  System.Reflection.Assembly.GetExecutingAssembly().base
        private string _exeFolderPath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
        private string _settingsFileName = "settings.json";
        private string _settingsFilePath;
        private string _saveCurrentTimesFileName = "current-times.txt";
        private string _savePreviousTimesFileName = "previous-times.txt";

        public SettingsManager()
        {
            _settingsFilePath = Path.Combine(_exeFolderPath, _settingsFileName);
            Directory.CreateDirectory(_exeFolderPath);
            if (!File.Exists(_settingsFilePath)) { CreateDefaultSettings(); }
        }

        private void CreateDefaultSettings()
        {
            int mainFormWidth = 214;

            Settings defaultSettings = new Settings()
            {
                SaveCurrentTimesFilePath = Path.Combine(_exeFolderPath, _saveCurrentTimesFileName),
                SavePreviousTimesFilePath = Path.Combine(_exeFolderPath, _savePreviousTimesFileName),
                WindowWidth = mainFormWidth,
                // temporary initial position where I like it
                // top right
                WindowPosX = Screen.PrimaryScreen.Bounds.Width - mainFormWidth + 5,
                WindowPosY = 0
            };
            SaveSettings(defaultSettings);
        }

        private void SaveSettings(Settings settings = null)
        {
            if (settings == null) { settings = Settings; }
            File.WriteAllText(_settingsFilePath, JsonConvert.SerializeObject(settings));
        }

        public Settings Settings { get => JsonConvert.DeserializeObject<Settings>(File.ReadAllText(_settingsFilePath)); }

        public object GetSetting(string name)
        {
            return Settings.GetType().GetProperty(name).GetValue(Settings);
        }

        public void SaveSetting(string name, object value)
        {
            Settings.GetType().GetProperty(name).SetValue(Settings, value.ToString());
            SaveSettings();
        }
    }

}
