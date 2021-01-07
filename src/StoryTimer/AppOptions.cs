namespace StoryTimer
{
    public record AppOptions(
        string Version = "",
        string SaveCurrentTimesFilePath = "",
        string SavePreviousTimesFilePath = "",
        int WindowPosX = 0,
        int WindowPosY = 0,
        int WindowWidth = 0
    );
}
