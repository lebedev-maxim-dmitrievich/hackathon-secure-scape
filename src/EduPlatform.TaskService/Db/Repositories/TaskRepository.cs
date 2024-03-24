using EduPlatform.TaskService.Db.Context;
using EduPlatform.TaskService.Db.Repositories.Interfaces;
using EduPlatform.TaskService.Entities;
using EduPlatform.TaskService.Enums;
using EduPlatform.TaskService.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
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

    public async Task<TaskEntity> GetTaskById(int id)
    {
        TaskEntity? task = await _dbContext.Tasks.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);

        if (task == null)
        {
            throw new NotFoundException(nameof(TaskEntity), id.ToString());
        }

        return task;
    }

    public async Task<List<TaskEntity>> GetTasks(string? topicName,
        string? difficultName)
    {
        var taskWithTopicQuery = _dbContext.Tasks
            .AsNoTracking()
            .Include(task => task.Topic);

        IQueryable<TaskEntity> tasksQuery;
        if (!string.IsNullOrEmpty(topicName))
        {
            tasksQuery = taskWithTopicQuery.Where(task => task.Topic.Title.Contains(topicName));
        }
        else
        {
            tasksQuery = taskWithTopicQuery;
        }

        if (!string.IsNullOrEmpty(difficultName))
        {
            tasksQuery = tasksQuery
                .Where(task => task.Difficult.Contains(difficultName));
        }

        return await tasksQuery.ToListAsync();
    }
}
