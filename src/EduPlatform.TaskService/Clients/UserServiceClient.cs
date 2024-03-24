using System.Net.Http;

namespace EduPlatform.TaskService.Clients;

public class UserServiceClient
{
    private const string _baseUrl = "localhost";
    private const int _port = 8080;
    private const string _urlUpdateProgress = "";

    private readonly HttpClient _httpClient;

    public UserServiceClient()
    {
        _httpClient = new HttpClient();
    }

    public void SendUpdateProgress()
    {

    }
}
