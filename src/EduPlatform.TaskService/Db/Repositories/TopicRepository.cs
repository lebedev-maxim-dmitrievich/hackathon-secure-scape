using EduPlatform.TaskService.Db.Context;
using EduPlatform.TaskService.Db.Repositories.Interfaces;
using EduPlatform.TaskService.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduPlatform.TaskService.Db.Repositories;

public class TopicRepository : ITopicRepository
{
    private readonly AppDbContext _dbContext;

    public TopicRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Topic>> GetTopics()
    {
        var topics = await _dbContext.Topics.ToListAsync();

        return topics;
    }
}
