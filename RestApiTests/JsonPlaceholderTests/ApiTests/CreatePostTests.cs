using System.Net;
using JsonPlaceholderTests.Clients;
using JsonPlaceholderTests.Models;
using JsonPlaceholderTests.Utils;

namespace JsonPlaceholderTests.ApiTests;

[TestFixture]
public class CreatePostTests
{
    private JsonPlaceholderClient _client;

    [Test]
    public void CreatePost_ShouldReturn201_WithCreatedData()
    {
        LogHelper.Step("SetUp: Инициализация API клиента");
        _client = new JsonPlaceholderClient();
        LogHelper.Info("API клиент успешно создан");

        LogHelper.Step("TEST 04: Создание нового поста через POST запрос");

        var newPost = new Post
        {
            UserId = TestDataProvider.ChangeableTestData.UserIdForPostInTestCase4,
            Title = TestDataGenerator.GenerateWord(),
            Body = TestDataGenerator.GenerateWord()
        };

        LogHelper.Info($"Подготовлен новый пост: userId={newPost.UserId}, " +
                       $"title='{newPost.Title}', body='{newPost.Body}'");

        LogHelper.Info("Отправка POST запроса к /posts");
        var response = _client.CreatePost(newPost);
        LogHelper.Info($"Получен ответ со статусом: {response.StatusCode}");

        LogHelper.Info("Проверка статус кода 201 Created");
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created),
            "Status code should be 201 Created");

        LogHelper.Info("Проверка что данные не null");
        Assert.That(response.Data, Is.Not.Null, "Response data should not be null");

        var expectedId = TestDataProvider.ChangeableTestData.ExpectedIdInTestCase4;
        LogHelper.Info($"Проверка что присвоен id={expectedId}");
        Assert.That(response.Data.Id, Is.EqualTo(expectedId), $"Created post should have id={expectedId}");

        LogHelper.Info("Проверка что userId совпадает");
        Assert.That(response.Data.UserId, Is.EqualTo(newPost.UserId), "UserId should match");

        LogHelper.Info("Проверка что title совпадает");
        Assert.That(response.Data.Title, Is.EqualTo(newPost.Title), "Title should match");

        LogHelper.Info("Проверка что body совпадает");
        Assert.That(response.Data.Body, Is.EqualTo(newPost.Body), "Body should match");

        LogHelper.Info($"✅ Пост успешно создан с id={response.Data.Id}");
    }
}
