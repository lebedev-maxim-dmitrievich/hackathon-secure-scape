using EduPlatform.TaskService.DTOs;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace EduPlatform.TaskService.Clients;

public class UserServiceClient
{
    private const string _baseUrl = "localhost";
    private const int _port = 8081;

    private readonly HttpClient _httpClient;

    private string _urlUpdateProgress => $"{_baseUrl}:{_port}/api/userprofile/";

    public UserServiceClient()
    {
        _httpClient = new HttpClient();
    }

    public async Task SendUpdateProgress(ProgressUpdateDto progressUpdate)
    {
        var requestOptions = new HttpRequestMessage(HttpMethod.Put, _urlUpdateProgress);

        requestOptions.Content = new StringContent(JsonSerializer.Serialize(progressUpdate));

        var response = await _httpClient.SendAsync(requestOptions);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Получение статус код {response.StatusCode}" +
                $"при обращении к {_urlUpdateProgress}");
        }
    }
}
