using System.Net;
using JsonPlaceholderTests.Clients;
using JsonPlaceholderTests.Utils;

namespace JsonPlaceholderTests.ApiTests;

[TestFixture]
public class GetPostById99Tests
{
    private JsonPlaceholderClient _client;

    [Test]
    public void GetPostById99_ShouldReturn200_WithCorrectData()
    {
        int postId = TestDataProvider.ChangeableTestData.ExistingEndpointNumber;
        int requiredPostId = TestDataProvider.ChangeableTestData.RequiredPostIdInPostNumber99;

        LogHelper.Step("SetUp: Инициализация API клиента");
        _client = new JsonPlaceholderClient();
        LogHelper.Info("API клиент успешно создан");

        LogHelper.Step($"TEST 02: Получение поста с id={postId}");

        LogHelper.Info($"ID поста из тестовых данных: {postId}");

        LogHelper.Info($"Отправка GET запроса к /posts/{postId}");
        var response = _client.GetPostById(postId);
        LogHelper.Info($"Получен ответ со статусом: {response.StatusCode}");

        LogHelper.Info("Проверка статус кода 200");
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK),
            "Status code should be 200");

        LogHelper.Info("Проверка что контент не пустой");
        Assert.That(response.Content, Is.Not.Null,
            "Content should not be null");

        LogHelper.Info($"Проверка что Id = {postId}");
        Assert.That(response.Data!.Id, Is.EqualTo(postId),
            $"Id should be {postId}");

        LogHelper.Info($"Проверка что UserId = {requiredPostId}");
        Assert.That(response.Data!.UserId, Is.EqualTo(requiredPostId),
            $"UserId should be {requiredPostId}");

        LogHelper.Info($"✅ Пост с id={postId} успешно получен и валидирован (userId={response.Data.UserId})");
    }
}
