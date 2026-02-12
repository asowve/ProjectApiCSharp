using Newtonsoft.Json.Linq;

namespace JsonPlaceholderTests.Utils;

public static class JsonValidator
{
    public static bool IsValidJson(string? content)
    {
        if (string.IsNullOrWhiteSpace(content))
        {
            return false;
        }

        try
        {
            JToken.Parse(content);
            return true;
        }
        catch
        {
            return false;
        }
    }
}
