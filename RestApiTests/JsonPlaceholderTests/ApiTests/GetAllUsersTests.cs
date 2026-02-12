using System.Net;
using JsonPlaceholderTests.Clients;
using JsonPlaceholderTests.Utils;

namespace JsonPlaceholderTests.ApiTests;

[TestFixture]
public class GetAllUsersTests
{
    private JsonPlaceholderClient _client;

    [Test]
    public void GetAllUsers_ShouldReturn200_AndContainUser5()
    {
        LogHelper.Step("SetUp: Инициализация API клиента");
        _client = new JsonPlaceholderClient();
        LogHelper.Info("API клиент успешно создан");

        var userIdNumber = TestDataProvider.ChangeableTestData.UserIdNumberForTestCase5;
        LogHelper.Step($"TEST 05: Получение всех пользователей и проверка user id={userIdNumber}");

        LogHelper.Info($"Загрузка ожидаемых данных для user id={userIdNumber} из тестовых данных");
        var expectedUser = TestDataProvider.GetExpectedUserById(userIdNumber);
        LogHelper.Info($"Ожидаемый пользователь: {expectedUser.Name} ({expectedUser.Email})");

        LogHelper.Info("Отправка GET запроса к /users");
        var response = _client.GetAllUsers();
        LogHelper.Info($"Получен ответ со статусом: {response.StatusCode}");

        LogHelper.Info("Проверка статус кода 200");
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK),
            "Status code should be 200");

        LogHelper.Info("Проверка что ответ содержит валидный JSON");
        Assert.That(JsonValidator.IsValidJson(response.Content), Is.True,
            "Response content should be valid JSON");

        LogHelper.Info("Проверка что список не пустой");
        Assert.That(response.Data, Is.Not.Null,
            "Response data should not be null");

        LogHelper.Info($"Поиск пользователя с id={userIdNumber} в списке");
        var actualUser = response.Data.FirstOrDefault(u => u.Id == userIdNumber);

        Assert.That(actualUser, Is.Not.Null,
            $"User with id={userIdNumber} should exist in the list");
        LogHelper.Info($"Пользователь с id={userIdNumber} найден: {actualUser.Name}");

        LogHelper.Info("Сравнение данных пользователя с ожидаемыми из тестовых данных");
        Assert.That(actualUser, Is.EqualTo(expectedUser),
            "User with id=5 should match expected test data");

        LogHelper.Info($"✅ Пользователь {actualUser.Name} (id={userIdNumber}) успешно валидирован");
    }
}
