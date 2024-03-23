using EduPlatform.UserService.DTOs.ProgresesDTO;
using EduPlatform.UserService.DTOs.TasksDTO;
using EduPlatform.UserService.DTOs.UsersDTO;
using EduPlatform.UserService.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduPlatform.UserService.Db.Repositories.Interfaces;

public interface IProfileRepository
{
    public Task<long> AddTask(TaskEntity task);

    public Task<ProgressVm?> GetProgress(long id);

    public Task<UserVm?> GetUser(long id);

    public Task<List<TaskVm>?> GetTasksUser(long id);

}
