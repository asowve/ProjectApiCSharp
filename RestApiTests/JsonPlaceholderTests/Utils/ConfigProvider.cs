using Aquality.Selenium.Browsers;
using Aquality.Selenium.Core.Configurations;

namespace JsonPlaceholderTests.Utils;

public static class ConfigProvider
{
    public static readonly string BaseUrl = AqualityServices.Get<ISettingsFile>().GetValue<string>("BaseUrl");
}
