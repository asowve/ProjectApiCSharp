using System.Reflection;
using Aquality.Selenium.Core.Utilities;
using JsonPlaceholderTests.Models;
using JsonPlaceholderTests.Resources.Constants;
using JsonPlaceholderTests.Resources.TestData.Models;
using Newtonsoft.Json;

namespace JsonPlaceholderTests.Utils;

public static class TestDataProvider
{
    private static readonly Lazy<ChangeableTestData> LazyData = new(() =>
    {
        LogHelper.Info("Загрузка тестовых данных");
        var path = ResourceConstants.PathToChangeableTestData;
        LogHelper.Info($"Путь к тестовым данным: {path}");

        var json = FileReader.GetTextFromEmbeddedResource(path, Assembly.GetExecutingAssembly());
        var data = JsonConvert.DeserializeObject<ChangeableTestData>(json) ?? new ChangeableTestData();

        LogHelper.Info($"Тестовые данные успешно загружены. Пользователей: {data.Users.Count}");
        return data;
    });

    public static ChangeableTestData ChangeableTestData => LazyData.Value;

    public static User GetExpectedUserById(int id)
    {
        var user = ChangeableTestData.Users.FirstOrDefault(u => u.Id == id);

        if (user == null)
        {
            LogHelper.Warning($"Пользователь с id={id} не найден в тестовых данных");
            throw new InvalidOperationException($"User with id={id} not found in test data");
        }

        LogHelper.Info($"Получен ожидаемый пользователь: {user.Name} (id={id})");
        return user;
    }
}
