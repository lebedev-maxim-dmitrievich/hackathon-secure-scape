using EduPlatform.TaskService.Db.Context;
using EduPlatform.TaskService.Db.Repositories.Interfaces;
using EduPlatform.TaskService.DTOs;
using EduPlatform.TaskService.Entities;
using EduPlatform.TaskService.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduPlatform.TaskService.Db.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly AppDbContext _dbContext;

    public TaskRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> CheckTaskAnswer(GiveAnswerDTO answerDto)
    {
        var task = await _dbContext.Tasks.FirstOrDefaultAsync(task => task.Id == answerDto.TaskId);

        if (task == null) 
        {
            throw new NotFoundException(nameof(TaskEntity), answerDto.TaskId.ToString());
        }

        return task.Answer == answerDto.Answer;
    }

    public async Task<TaskEntity> GetTaskById(long id)
    {
        TaskEntity? task = await _dbContext.Tasks.AsNoTracking()
            .Include(task => task.Topic)
            .FirstOrDefaultAsync(t => t.Id == id);

        if (task == null)
        {
            throw new NotFoundException(nameof(TaskEntity), id.ToString());
        }

        return task;
    }

    public async Task<List<TaskEntity>> GetTasks(string? topicName,
        string? difficultName)
    {
        var taskQuery = _dbContext.Tasks
            .AsNoTracking();

        if (!string.IsNullOrEmpty(topicName))
        {
            taskQuery = taskQuery
                .Where(task => task.Topic.Title
                .Contains(topicName));
        }

        if (!string.IsNullOrEmpty(difficultName))
        {
            taskQuery = taskQuery
                .Where(task => task.Difficult.Contains(difficultName));
        }

        taskQuery = taskQuery.Include(task => task.Topic);

        return await taskQuery.ToListAsync();
    }
}
