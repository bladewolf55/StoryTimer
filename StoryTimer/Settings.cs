using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Windows.Forms;

namespace StoryTimer
{
    public class Settings
    {
        public string SaveFolderPath { get; set; }
        public int WindowPosX { get; set; }
        public int WindowPosY { get; set; }
        public int WindowWidth { get; set; }
    }



    public class SettingsManager
    {
        //  System.Reflection.Assembly.GetExecutingAssembly().base
        private string _exeFolderPath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
        private string _settingsFileName = "settings.json";
        private string _settingsFilePath;
        private string _saveFolderName = "current-times.txt";

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
                SaveFolderPath = Path.Combine(_exeFolderPath, _saveFolderName),
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
