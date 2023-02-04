using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Text.Json;


namespace StoryTimer
{
    public class SettingsManager
    {
        public const string AppSettingsFileName = "appsettings.json";
        private IHostEnvironment _hostEnvironment;
        private readonly string _appSettingsFilePath;

        public SettingsManager(IHostEnvironment hostEnvironment = null)
        {
            _hostEnvironment = hostEnvironment ?? Program.Services.GetService<IHostEnvironment>();
            _appSettingsFilePath = _hostEnvironment.ContentRootFileProvider.GetFileInfo(AppSettingsFileName).PhysicalPath;
        }

        public void CreateSettingsFiles(AppOptions options)
        {
            SaveSettingFile(options.SaveCurrentTimesFilePath);
            SaveSettingFile(options.SavePreviousTimesFilePath);
            SaveSettingFile(options.SaveSnippetsFilePath);
        }

        private void SaveSettingFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                File.WriteAllText(filePath, "");
            }

        }

        public void SaveAppOptions(AppOptions options)
        {
            CreateSettingsFiles(options);
            var appSettings = GetAppSettings();
            appSettings.AppOptions = options;
            string text = JsonSerializer.Serialize<AppSettings>(appSettings, new JsonSerializerOptions() { WriteIndented = true });
            File.WriteAllText(_appSettingsFilePath, text);
        }

        public AppSettings GetAppSettings()
        {
            string settings = File.ReadAllText(_appSettingsFilePath);
            var appSettings = JsonSerializer.Deserialize<AppSettings>(settings);
            return appSettings;
        }
    }
}
