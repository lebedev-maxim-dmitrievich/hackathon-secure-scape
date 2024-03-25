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
        string? entryServiceHost = Environment.GetEnvironmentVariable(config[_entryServiceHostEnvKey] ?? "");
        string? entryServicePort = Environment.GetEnvironmentVariable(config[_entryServicePortEnvKey] ?? "");

        if (string.IsNullOrWhiteSpace(entryServiceHost) || string.IsNullOrWhiteSpace(entryServicePort))
        {
            throw new Exception("Не указаны хост или порт сервиса entry в переменных окружения");
        }

        EntryServiceUrl = $"http://{entryServiceHost}:{entryServicePort}";
    }
}
