using JsonPlaceholderTests.Utils;
using RestSharp;

namespace JsonPlaceholderTests.Clients;

public class BaseApi
{
    protected static RestResponse<T> Get<T>(RestClient client, string endpoint)
    {
        var request = new RestRequest(endpoint, Method.Get);

        LogHelper.Info($"[BaseApi] Отправка GET запроса: {client.Options.BaseUrl}{endpoint}");
        var response = client.Execute<T>(request);

        LogHelper.Info(
            $"[BaseApi] Получен ответ: StatusCode={response.StatusCode}, ContentLength={response.Content?.Length ?? 0}");

        if (!response.IsSuccessful)
        {
            LogHelper.Warning($"[BaseApi] Запрос завершился с ошибкой: {response.ErrorMessage}");
        }

        return response;
    }

    protected static RestResponse<T> Post<T>(RestClient client, string endpoint, object body)
    {
        var request = new RestRequest(endpoint, Method.Post);
        request.AddJsonBody(body);

        LogHelper.Info($"[BaseApi] Отправка POST запроса: {client.Options.BaseUrl}{endpoint}");
        LogHelper.Info($"[BaseApi] Тело запроса: {Newtonsoft.Json.JsonConvert.SerializeObject(body)}");

        var response = client.Execute<T>(request);

        LogHelper.Info(
            $"[BaseApi] Получен ответ: StatusCode={response.StatusCode}, ContentLength={response.Content?.Length ?? 0}");

        if (!response.IsSuccessful)
        {
            LogHelper.Warning($"[BaseApi] Запрос завершился с ошибкой: {response.ErrorMessage}");
        }

        return response;
    }
}
