using System.Net;
using JsonPlaceholderTests.Clients;
using JsonPlaceholderTests.Utils;

namespace JsonPlaceholderTests.ApiTests;

[TestFixture]
public class GetPostById150Tests
{
    private JsonPlaceholderClient _client;

    [Test]
    public void GetPostById150_ShouldReturn404_WithEmptyBody()
    {
        int postId = TestDataProvider.ChangeableTestData.NotExistingEndpointNumber;
        string? bodyEmptyCondition = TestDataProvider.ChangeableTestData.BodyEmptyCondition;

        LogHelper.Step("SetUp: Инициализация API клиента");
        _client = new JsonPlaceholderClient();
        LogHelper.Info("API клиент успешно создан");

        LogHelper.Step($"TEST 03: Получение несуществующего поста с id={postId} (негативный сценарий)");

        LogHelper.Info($"ID несуществующего поста: {postId}");
        LogHelper.Info($"Ожидаемое тело ответа: '{bodyEmptyCondition}'");

        LogHelper.Info($"Отправка GET запроса к /posts/{postId}");
        var response = _client.GetPostById(postId);
        LogHelper.Info($"Получен ответ со статусом: {response.StatusCode}");

        LogHelper.Info("Проверка статус кода 404 Not Found");
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound),
            "Status code should be 404 for non-existent post");

        LogHelper.Info("Проверка что тело ответа пустое");
        Assert.That(response.Content, Is.EqualTo(bodyEmptyCondition),
            $"Response body should be empty object {bodyEmptyCondition}");

        LogHelper.Info("Проверка что данные null");
        Assert.That(response?.Data?.Body, Is.Null,
            "Response data.Body should be null");

        LogHelper.Info($"✅ Несуществующий пост корректно вернул 404 с пустым телом");
    }
}
