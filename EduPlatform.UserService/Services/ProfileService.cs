using EduPlatform.UserService.Db.Repositories.Interfaces;
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
            var task = taskVm == null ? null : _mapper.ToMap<TaskEntity>(taskVm);

            if (task != null) 
            {
                long id = await _profileRepository.AddTask(task);

                return id;
            }
            return null;
        }

        public async Task<List<TaskVm>?> GetAllTasksByUserId(long id)
        {
            return await _profileRepository.GetTasksUser(id);
        }

        public async Task<ProgressVm?> GetProgresById(long id)
        {
            return await _profileRepository.GetProgress(id);
        }

        public async Task<UserVm?> GetUserById(long id)
        {
            return await _profileRepository.GetUser(id);
        }
    }
}
