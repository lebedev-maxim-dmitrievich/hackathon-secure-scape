using EduPlatform.TaskService.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduPlatform.TaskService.Db.Repositories.Interfaces;

public interface ITopicRepository
{
    public Task<List<Topic>> GetTopics();
}
