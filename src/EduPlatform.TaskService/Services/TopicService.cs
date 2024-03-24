using EduPlatform.TaskService.Db.Repositories.Interfaces;
using EduPlatform.TaskService.DTOs;
using System.Threading.Tasks;

namespace EduPlatform.TaskService.Services;

public class TopicService : ITopicService
{
    private readonly ITopicRepository _topicRepository;

    public TopicService(ITopicRepository topicRepository)
    {
        _topicRepository = topicRepository;
    }
    public async Task<TopicsVm> GetTopics()
    {
        var topics = await _topicRepository.GetTopics();

        return new TopicsVm(topics);
    }
}
