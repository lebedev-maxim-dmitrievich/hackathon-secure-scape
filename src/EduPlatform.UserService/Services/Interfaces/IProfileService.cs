using EduPlatform.UserService.DTOs.AchievementsDTO;
using EduPlatform.UserService.DTOs.ProgresesDTO;
using EduPlatform.UserService.DTOs.TasksDTO;
using EduPlatform.UserService.DTOs.UsersDTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduPlatform.UserService.Services.Interfaces
{
    public interface IProfileService
    {
        public Task<ProgressVm?> GetProgresById(long id);

        public Task<UserVm?> GetUserById(long id);

        public Task<List<TaskVm>?> GetAllTasksByUserId(long id);

        public Task<List<UserAchievementProgressVm>?> GetUserAchievements(long id);

        //public Task<List<long>> UpdateAchievments(ProgressUpdateVm progressVm);

        public Task<long> UpdateProgress(ProgressUpdateVm progressVm);
    }
}
