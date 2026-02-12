using System.Net;
using JsonPlaceholderTests.Clients;
using JsonPlaceholderTests.Utils;

namespace JsonPlaceholderTests.ApiTests;

[TestFixture]
public class GetAllPostsTests
{
    private JsonPlaceholderClient _client;

    [Test]
    public void GetAllPosts_ShouldReturn200_WithSortedList()
    {
        LogHelper.Step("SetUp: Инициализация API клиента");
        _client = new JsonPlaceholderClient();
        LogHelper.Info("API клиент успешно создан");

        LogHelper.Step("TEST 01: Получение всех постов и проверка сортировки");

        LogHelper.Info("Отправка GET запроса к /posts");
        var response = _client.GetAllPosts();
        LogHelper.Info($"Получен ответ со статусом: {response.StatusCode}");

        LogHelper.Info("Проверка статус кода 200");
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK),
            "Status code should be 200");

        LogHelper.Info("Проверка что ответ содержит валидный JSON");
        Assert.That(JsonValidator.IsValidJson(response.Content), Is.True,
            "Response content should be valid JSON");

        LogHelper.Info("Проверка что данные не пустые");
        Assert.That(response.Data, Is.Not.Null,
            "Response data should not be null");

        Assert.That(response.Data.Count, Is.GreaterThan(0),
            "Posts list should not be empty");

        LogHelper.Info($"Получено постов: {response.Data.Count}");

        LogHelper.Info("Проверка сортировки постов по ID");
        var posts = response.Data;
        for (int i = 0; i < posts.Count - 1; i++)
        {
            Assert.That(posts[i].Id, Is.LessThan(posts[i + 1].Id),
                $"Posts should be sorted by Id. Post at index {i} (Id={posts[i].Id})" +
                $" should be less than post at index {i + 1} (Id={posts[i + 1].Id})");
        }

        LogHelper.Info($"✅ Все посты отсортированы корректно (первый Id={posts[0].Id}, последний Id={posts[^1].Id})");
    }
}
