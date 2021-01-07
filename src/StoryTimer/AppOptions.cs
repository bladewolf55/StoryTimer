namespace StoryTimer
{
    public class AppOptions
    {
        public string Version { get; set; }
        public string SaveCurrentTimesFilePath { get; set; }
        public string SavePreviousTimesFilePath { get; set; }
        public int WindowPosX { get; set; }
        public int WindowPosY { get; set; }
        public int WindowWidth { get; set; }

        public AppOptions()
        {

        }
        public AppOptions(string Version, string SaveCurrentTimesFilePath, string SavePreviousTimesFilePath,
            int WindowPosX, int WindowPosY, int WindowWidth
            )
        {
            this.Version = Version;
            this.SaveCurrentTimesFilePath = SaveCurrentTimesFilePath;
            this.SavePreviousTimesFilePath = SavePreviousTimesFilePath;
            this.WindowPosX = WindowPosX;
            this.WindowPosY = WindowPosY;
            this.WindowWidth = WindowWidth;
        }

    }

    //public record AppOptions(
    //    string Version = "",
    //    string SaveCurrentTimesFilePath = "",
    //    string SavePreviousTimesFilePath = "",
    //    int WindowPosX = 0,
    //    int WindowPosY = 0,
    //    int WindowWidth = 0
    //);
}
