using EduPlatform.TaskService.Db.Repositories.Interfaces;
using EduPlatform.TaskService.DTOs;
using EduPlatform.TaskService.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace EduPlatform.TaskService.Services;

public class TaskHandlerService : ITaskService
{
    private readonly ITaskRepository _taskRepository;

    public TaskHandlerService(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<bool> CheckAnswer(GiveAnswerDTO answerDto)
    {
        return await _taskRepository.CheckTaskAnswer(answerDto);
    }

    public async Task<TaskVm> GetTaskById(int id)
    {
        TaskEntity task = await _taskRepository.GetTaskById(id);

        var taskVm = new TaskVm(task.Id, task.Title, task.Description, task.Topic.Title,
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

        var tasksPresentation = new List<TaskVm>();

        foreach (var task in tasks)
        {
            tasksPresentation.Add(
                new(
                    task.Id, task.Title, task.Description, task.Topic.Title,
                    task.FileLocation, task.IconLocation, task.Difficult, task.Points
                ));
        }

        return new TasksVm(tasksPresentation);
    }

    public async Task UpdateUserProgress(long userId, long taskId)
    {
        var task = await _taskRepository.GetTaskById(taskId);

        var progressUpdate = new ProgressUpdateDto(userId, task.Id,
            task.Points, task.Topic.Title, task.Difficult);

        throw new NotImplementedException("g");
    }
}
