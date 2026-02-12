using System.Net;
using JsonPlaceholderTests.Clients;
using JsonPlaceholderTests.Utils;

namespace JsonPlaceholderTests.ApiTests;

[TestFixture]
public class GetUserById5Tests
{
    private JsonPlaceholderClient _client;

    [Test]
    public void GetUserById5_ShouldMatchExpectedUser()
    {
        int userId = TestDataProvider.ChangeableTestData.UserIdNumberForTestCase5;
        LogHelper.Step("SetUp: Инициализация API клиента");
        _client = new JsonPlaceholderClient();
        LogHelper.Info("API клиент успешно создан");

        LogHelper.Step($"TEST 06: Получение пользователя с id={userId} и детальная проверка всех полей");

        LogHelper.Info($"Загрузка ожидаемых данных для user id={userId}");
        var expectedUser = TestDataProvider.GetExpectedUserById(userId);
        LogHelper.Info($"Ожидаемый пользователь: {expectedUser.Name} ({expectedUser.Email})");

        LogHelper.Info($"Отправка GET запроса к /users/{userId}");
        var response = _client.GetUserById(userId);
        LogHelper.Info($"Получен ответ со статусом: {response.StatusCode}");

        LogHelper.Info("Проверка статус кода 200");
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK),
            "Status code should be 200");

        LogHelper.Info("Проверка что данные не null");
        Assert.That(response.Data, Is.Not.Null,
            "Response data should not be null");

        LogHelper.Info("Сравнение всех полей пользователя с ожидаемыми данными");
        Assert.That(response.Data, Is.EqualTo(expectedUser),
            "Actual user should match expected user from test data");

        LogHelper.Info($"✅ Пользователь {response.Data.Name} (id={userId}) полностью соответствует тестовым данным");
        LogHelper.Info($"   - Email: {response.Data.Email}");
        LogHelper.Info($"   - Address: {response.Data.Address.Street}, {response.Data.Address.City}");
        LogHelper.Info($"   - Company: {response.Data.Company.Name}");
    }
}
