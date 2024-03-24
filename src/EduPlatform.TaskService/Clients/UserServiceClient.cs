using EduPlatform.TaskService.DTOs;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EduPlatform.TaskService.Clients;

public class UserServiceClient
{
    private const string _baseUrl = "http://user-service";
    private const int _port = 8080;

    private readonly HttpClient _httpClient;

    private string _urlUpdateProgress => $"{_baseUrl}:{_port}/api/userprofile/";

    public UserServiceClient()
    {
        _httpClient = new HttpClient();
    }

    public async Task SendUpdateProgress(ProgressUpdateDto progressUpdate)
    {
        var requestMessage = new HttpRequestMessage(HttpMethod.Put, _urlUpdateProgress);

        requestMessage.Content = new StringContent(JsonSerializer.Serialize(progressUpdate),
            Encoding.UTF8, "application/json");

        var response = await _httpClient.SendAsync(requestMessage);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Получение статус код {response.StatusCode}" +
                $"при обращении к {_urlUpdateProgress}");
        }
    }
}
