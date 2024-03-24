using EduPlatform.TaskService.Clients;
using EduPlatform.TaskService.Db.Repositories.Interfaces;
using EduPlatform.TaskService.DTOs;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace EduPlatform.TaskService.Services;

public class TopicService : ITopicService
{
    private readonly ITopicRepository _topicRepository;
    private readonly EntryServiceClient _entryServiceClient;

    public TopicService(ITopicRepository topicRepository, IConfiguration config)
    {
        _topicRepository = topicRepository;

        _entryServiceClient = new EntryServiceClient(config);
    }
    public async Task<TopicsVm> GetTopics()
    {
        var topics = await _topicRepository.GetTopics();

        foreach (var topic in topics)
        {
            topic.ImageLocation = $"{_entryServiceClient.EntryServiceUrl}/{topic.ImageLocation}";
        }

        return new TopicsVm(topics);
    }
}
