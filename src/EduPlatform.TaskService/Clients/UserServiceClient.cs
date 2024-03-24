using EduPlatform.TaskService.Db.Repositories.Interfaces;
using EduPlatform.TaskService.DTOs;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EduPlatform.TaskService.Clients;

public class UserServiceClient
{
    private const string _userServiceHostEnvKey = "UserServiceHostEnv";
    private const string _userServicePortEnvKey = "UserServicePostEnv";

    private readonly string _userServiceUrl;
    private readonly HttpClient _httpClient;

    private string _updateProgressUrl => $"{_userServiceUrl}/api/userprofile/updateProgress";


    public UserServiceClient(IConfiguration config)
    {
        _httpClient = new HttpClient();

        string? userServiceHost = Environment.GetEnvironmentVariable(config[_userServiceHostEnvKey] ?? "");
        string? userServicePort = Environment.GetEnvironmentVariable(config[_userServicePortEnvKey] ?? "");

        if (string.IsNullOrWhiteSpace(userServiceHost) || string.IsNullOrWhiteSpace(userServicePort))
        {
            throw new Exception("Не указаны хост или порт сервиса пользователей в переменных окружения");
        }

        _userServiceUrl = $"http://{userServiceHost}:{userServicePort}";
    }

    public async Task SendUpdateProgress(ProgressUpdateDto progressUpdate)
    {
        var requestMessage = new HttpRequestMessage(HttpMethod.Put, _updateProgressUrl);

        requestMessage.Content = new StringContent(JsonSerializer.Serialize(progressUpdate),
            Encoding.UTF8, "application/json");

        var response = await _httpClient.SendAsync(requestMessage);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Получение статус код {response.StatusCode}" +
                $"при обращении к {_userServiceUrl}");
        }
    }
}
