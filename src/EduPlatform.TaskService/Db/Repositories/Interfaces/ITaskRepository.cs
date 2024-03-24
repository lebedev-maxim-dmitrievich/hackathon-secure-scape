using EduPlatform.TaskService.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduPlatform.TaskService.Db.Repositories.Interfaces;

public interface ITaskRepository
{
    public Task<TaskEntity> GetTaskById(int id);

    public Task<List<TaskEntity>> GetTasks(string? topicName,
        string? difficultName);
}
