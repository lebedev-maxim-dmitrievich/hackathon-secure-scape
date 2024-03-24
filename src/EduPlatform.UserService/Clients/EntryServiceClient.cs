using Microsoft.Extensions.Configuration;
using System;

namespace EduPlatform.UserService.Clients;

public class EntryServiceClient
{
    private const string _entryServiceHostEnvKey = "EntryHostEnv";
    private const string _entryServicePortEnvKey = "EntryPortEnv";

    public string EntryServiceUrl { get; set; }

    public EntryServiceClient(IConfiguration config)
    {
        string? userServiceHost = Environment.GetEnvironmentVariable(config[_entryServiceHostEnvKey] ?? "");
        string? userServicePort = Environment.GetEnvironmentVariable(config[_entryServicePortEnvKey] ?? "");

        if (string.IsNullOrWhiteSpace(userServiceHost) || string.IsNullOrWhiteSpace(userServicePort))
        {
            throw new Exception("Не указаны хост или порт сервиса пользователей в переменных окружения");
        }

        EntryServiceUrl = $"http://{userServiceHost}:{userServicePort}";
    }
}
