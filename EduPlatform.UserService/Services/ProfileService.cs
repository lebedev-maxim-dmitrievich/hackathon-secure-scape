using EduPlatform.UserService.Db.Repositories.Interfaces;
using EduPlatform.UserService.DTOs.AchivementsDTO;
using EduPlatform.UserService.DTOs.ProgresesDTO;
using EduPlatform.UserService.DTOs.TasksDTO;
using EduPlatform.UserService.DTOs.UsersDTO;
using EduPlatform.UserService.Entity;
using EduPlatform.UserService.Mappers.Interfaces;
using EduPlatform.UserService.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduPlatform.UserService.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _profileRepository;
        private ISimpleMapper _mapper;

        public ProfileService(IProfileRepository profileRepository, ISimpleMapper mapper) 
        {
            _profileRepository = profileRepository;
            _mapper = mapper;
        }

        public async Task<long?> AddTaskInProgress(TaskVm taskVm)
        {
            var task = _mapper.ToMap<TaskEntity>(taskVm);

            long id = await _profileRepository.AddTask(task);

            return id;
        }

        public async Task<List<TaskVm>?> GetAllTasksByUserId(long id)
        {
            if (!_profileRepository.CheckUser(id).Result) return null;

            return await _profileRepository.GetTasksUser(id);
        }

        public async Task<ProgressVm?> GetProgresById(long id)
        {
            if (!_profileRepository.CheckUser(id).Result) return null;

            return await _profileRepository.GetProgress(id);
        }

        public async Task<List<AchievementVm>?> GetUserAchivements(long id)
        {
            if (!_profileRepository.CheckUser(id).Result) return null;

            return await _profileRepository.GetAchivements(id);
        }

        public async Task<UserVm?> GetUserById(long id)
        {
            return await _profileRepository.GetUser(id);
        }
    }
}
