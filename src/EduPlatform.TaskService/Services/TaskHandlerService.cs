using EduPlatform.TaskService.Db.Repositories.Interfaces;
using EduPlatform.TaskService.DTOs;
using EduPlatform.TaskService.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduPlatform.TaskService.Services;

public class TaskHandlerService : ITaskService
{
    private readonly ITaskRepository _taskRepository;

    public TaskHandlerService(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<TaskVm> GetTaskById(int id)
    {
        TaskEntity task = await _taskRepository.GetTaskById(id);

        var taskVm = new TaskVm(task.Id, task.Title, task.Description, task.Exercise,
            task.FileLocation, task.IconLocation, task.Difficult, task.Points);

        return taskVm;
    }

    public async Task<TasksVm> GetTasks(string? topicName, string? difficultName)
    {
        if (string.IsNullOrEmpty(difficultName))
        {
            difficultName = null;
        }

        var tasks = await _taskRepository.GetTasks(topicName, difficultName);

        var tasksPresentation = new List<TaskPresentationVm>();

        foreach (var task in tasks)
        {
            tasksPresentation.Add(
                new(
                    task.Id, task.Title, task.Description,
                    task.Difficult, task.IconLocation
                ));
        }

        return new TasksVm(tasksPresentation);
    }
}
