using EduPlatform.TaskService.DTOs;
using System.Threading.Tasks;

namespace EduPlatform.TaskService.Services;

public interface ITopicService
{
    public Task<TopicsVm> GetTopics();
}
