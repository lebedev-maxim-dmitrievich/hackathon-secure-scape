using EduPlatform.TaskService.DTOs;
using System.Threading.Tasks;

namespace EduPlatform.TaskService.Services;

public interface ITaskService
{
    public Task<TaskVm> GetTaskById(int id);

    public Task<TasksVm> GetTasks(string? topicName, string? difficultName);

    public Task<bool> CheckAnswer(GiveAnswerDTO answerDto);

    public Task UpdateUserProgress(long userId, long taskId);
}
