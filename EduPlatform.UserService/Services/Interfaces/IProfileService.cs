using EduPlatform.UserService.DTOs.ProgresesDTO;
using EduPlatform.UserService.DTOs.TasksDTO;
using EduPlatform.UserService.DTOs.UsersDTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduPlatform.UserService.Services.Interfaces
{
    public interface IProfileService
    {
        public Task<ProgressVm?> GetProgresById(long id);

        public Task<UserVm?> GetUserById(long id);

        public Task<List<TaskVm>?> GetAllTasksByUserId(long id);

        public Task<long?> AddTaskInProgress(TaskVm taskVm);
    }
}
