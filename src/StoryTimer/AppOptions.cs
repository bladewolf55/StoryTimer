using System.Linq;

namespace StoryTimer
{
    public class AppOptions
    {
        public string Version { get; set; }
        public string SaveCurrentTimesFilePath { get; set; }
        public string SavePreviousTimesFilePath { get; set; }
        public string SaveSnippetsFilePath { get; set; }
        public int WindowPosX { get; set; }
        public int WindowPosY { get; set; }
        public int WindowWidth { get; set; }

        public AppOptions() { }

        public AppOptions(string Version, string SaveCurrentTimesFilePath,
            string SavePreviousTimesFilePath, string SaveSnippetsFilePath,
            int WindowPosX, int WindowPosY, int WindowWidth
            )
        {
            this.SaveSnippetsFilePath = SaveSnippetsFilePath;
            this.Version = Version;
            this.SaveCurrentTimesFilePath = SaveCurrentTimesFilePath;
            this.SavePreviousTimesFilePath = SavePreviousTimesFilePath;
            this.WindowPosX = WindowPosX;
            this.WindowPosY = WindowPosY;
            this.WindowWidth = WindowWidth;
        }

        public bool SettingsVersionLessThan(string version)
        {
            int settingsVersion = VersionToInt(this.Version);
            int compare = VersionToInt(version);
            return settingsVersion < compare;
        }

        private int VersionToInt(string version)
        {
            string[] parts = version.Split('.');
            // combine parts but pad minor and patch to four places
            // 1.7.3      = 100070003
            // 12.34.567 = 1200340567

            string padded = parts[0] + parts[1].PadLeft(4, '0') + parts[2].PadLeft(5, '0');
            int intVersion = int.Parse(padded);
            return intVersion;
        }
    }
}
