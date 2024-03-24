using EduPlatform.TaskService.DTOs;
using System.Threading.Tasks;

namespace EduPlatform.TaskService.Services;

public interface ITaskService
{
    public Task<TaskVm> GetTaskById(int id);

    public Task<TasksVm> GetTasks(string? topicName, string? difficultName);
}
