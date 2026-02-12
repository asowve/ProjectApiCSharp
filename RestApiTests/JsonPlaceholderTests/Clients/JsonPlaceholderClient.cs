using JsonPlaceholderTests.Models;
using JsonPlaceholderTests.Utils;
using RestSharp;

namespace JsonPlaceholderTests.Clients;

public class JsonPlaceholderClient : BaseApi
{
    public RestResponse<List<Post>> GetAllPosts()
    {
        LogHelper.Info("[Client] Вызван метод GetAllPosts()");
        var endpoint = Endpoints.GetAllPostsEndpoint();
        var client = new RestClient(ConfigProvider.BaseUrl);
        LogHelper.Info($"[Client] BaseUrl: {ConfigProvider.BaseUrl}, Endpoint: {endpoint}");

        var response = Get<List<Post>>(client, endpoint);

        LogHelper.Info($"[Client] GetAllPosts завершен. Получено постов: {response.Data?.Count ?? 0}");
        return response;
    }

    public RestResponse<Post> GetPostById(int id)
    {
        LogHelper.Info($"[Client] Вызван метод GetPostById(id={id})");
        var endpoint = Endpoints.GetPostByIdEndpoint(id);
        var client = new RestClient(ConfigProvider.BaseUrl);
        LogHelper.Info($"[Client] BaseUrl: {ConfigProvider.BaseUrl}, Endpoint: {endpoint}");

        var response = Get<Post>(client, endpoint);

        if (response.Data != null)
        {
            LogHelper.Info(
                $"[Client] GetPostById завершен. Получен пост: Id={response.Data.Id}, UserId={response.Data.UserId}");
        }
        else
        {
            LogHelper.Warning($"[Client] GetPostById завершен. Данные отсутствуют (StatusCode={response.StatusCode})");
        }

        return response;
    }

    public RestResponse<Post> CreatePost(Post post)
    {
        LogHelper.Info($"[Client] Вызван метод CreatePost()");
        LogHelper.Info($"[Client] Создаваемый пост: UserId={post.UserId}, Title='{post.Title}', Body='{post.Body}'");

        var endpoint = Endpoints.CreatePostEndpoint();
        var client = new RestClient(ConfigProvider.BaseUrl);
        LogHelper.Info($"[Client] BaseUrl: {ConfigProvider.BaseUrl}, Endpoint: {endpoint}");

        var response = Post<Post>(client, endpoint, post);

        if (response.Data != null)
        {
            LogHelper.Info($"[Client] CreatePost завершен. Создан пост с Id={response.Data.Id}");
        }
        else
        {
            LogHelper.Warning($"[Client] CreatePost завершен. Данные отсутствуют (StatusCode={response.StatusCode})");
        }

        return response;
    }

    public RestResponse<List<User>> GetAllUsers()
    {
        LogHelper.Info("[Client] Вызван метод GetAllUsers()");
        var endpoint = Endpoints.GetAllUsersEndpoint();
        var client = new RestClient(ConfigProvider.BaseUrl);
        LogHelper.Info($"[Client] BaseUrl: {ConfigProvider.BaseUrl}, Endpoint: {endpoint}");

        var response = Get<List<User>>(client, endpoint);

        LogHelper.Info($"[Client] GetAllUsers завершен. Получено пользователей: {response.Data?.Count ?? 0}");
        return response;
    }

    public RestResponse<User> GetUserById(int id)
    {
        LogHelper.Info($"[Client] Вызван метод GetUserById(id={id})");
        var endpoint = Endpoints.GetUserByIdEndpoint(id);
        var client = new RestClient(ConfigProvider.BaseUrl);
        LogHelper.Info($"[Client] BaseUrl: {ConfigProvider.BaseUrl}, Endpoint: {endpoint}");

        var response = Get<User>(client, endpoint);

        if (response.Data != null)
        {
            LogHelper.Info(
                $"[Client] GetUserById завершен. Получен пользователь: Id={response.Data.Id}, Name='{response.Data.Name}', " +
                $"Email='{response.Data.Email}'");
        }
        else
        {
            LogHelper.Warning($"[Client] GetUserById завершен. Данные отсутствуют (StatusCode={response.StatusCode})");
        }

        return response;
    }
}

public static class Endpoints
{
    public static string GetAllPostsEndpoint() => "/posts";

    public static string GetPostByIdEndpoint(int id) => $"/posts/{id}";

    public static string CreatePostEndpoint() => "/posts";

    public static string GetAllUsersEndpoint() => "/users";

    public static string GetUserByIdEndpoint(int id) => $"/users/{id}";
}
