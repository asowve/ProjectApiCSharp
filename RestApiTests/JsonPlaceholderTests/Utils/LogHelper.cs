using Aquality.Selenium.Core.Logging;

namespace JsonPlaceholderTests.Utils;

public static class LogHelper
{
    private static Logger Log => Logger.Instance;

    public static void Info(string message) => Log.Info(message);

    public static void Error(string message) => Log.Error(message);

    public static void Warning(string message) => Log.Warn(message);

    public static void Step(string stepName)
    {
        var separator = new string('-', 60);
        Log.Info($"\n{separator}\n{stepName}\n{separator}");
    }
}
