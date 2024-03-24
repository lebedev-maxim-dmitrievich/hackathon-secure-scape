using EduPlatform.TaskService.Clients;
using EduPlatform.TaskService.Db.Repositories.Interfaces;
using EduPlatform.TaskService.DTOs;
using EduPlatform.TaskService.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduPlatform.TaskService.Services;

public class TaskHandlerService : ITaskService
{
    private readonly ITaskRepository _taskRepository;
    private readonly IConfiguration _configuration;
    private readonly EntryServiceClient _entryServiceClient;

    public TaskHandlerService(ITaskRepository taskRepository, IConfiguration configuration)
    {
        _taskRepository = taskRepository;
        _configuration = configuration;

        _entryServiceClient = new EntryServiceClient(configuration);
    }

    public async Task<bool> CheckAnswer(GiveAnswerDTO answerDto)
    {
        return await _taskRepository.CheckTaskAnswer(answerDto);
    }

    public async Task<TaskVm> GetTaskById(int id)
    {
        TaskEntity task = await _taskRepository.GetTaskById(id);

        var taskVm = new TaskVm(task.Id, task.Title, task.Description, task.Topic.Title,
            $"{_entryServiceClient.EntryServiceUrl}/{task.FileLocation}",
            $"{_entryServiceClient.EntryServiceUrl}/{task.IconLocation}", task.Difficult, task.Points);

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
                    $"{_entryServiceClient.EntryServiceUrl}/{task.FileLocation}",
                    $"{_entryServiceClient.EntryServiceUrl}/{task.IconLocation}",
                    task.Difficult, task.Points
                ));
        }

        return new TasksVm(tasksPresentation);
    }

    public async Task UpdateUserProgress(long userId, long taskId)
    {
        var task = await _taskRepository.GetTaskById(taskId);

        var progressUpdate = new ProgressUpdateDto(userId, task.Id,
            task.Points, task.Topic.Title, task.Difficult);

        var userServiceClient = new UserServiceClient(_configuration);
        await userServiceClient.SendUpdateProgress(progressUpdate);
    }
}
