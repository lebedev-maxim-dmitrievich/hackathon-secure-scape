using EduPlatform.UserService.Db.Repositories.Interfaces;
using EduPlatform.UserService.DTOs.AchivementsDTO;
using EduPlatform.UserService.DTOs.ProgresesDTO;
using EduPlatform.UserService.DTOs.TasksDTO;
using EduPlatform.UserService.DTOs.UsersDTO;
using EduPlatform.UserService.Entity;
using EduPlatform.UserService.Enum;
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

        public async Task<List<UserAchievementProgressVm>?> GetUserAchievements(long id)
        {
            if (!_profileRepository.CheckUser(id).Result) return null;

            return await _profileRepository.GetUserAchivements(id);
        }

        public async Task<UserVm?> GetUserById(long id)
        {
            return await _profileRepository.GetUser(id);
        }

        public async Task<long> UpdateProgress(ProgressUpdateVm progressVm)
        {
            var task = new TaskEntity()
            {
                ExternalTaskId = progressVm.TaskId,
                ProgressId = progressVm.UserId,
            };

            await _profileRepository.AddTask(task);

            var progressDTO = await _profileRepository.GetProgress(progressVm.UserId);
            if (progressDTO != null)
            {
                progressDTO.Scores += progressVm.TaskPoint;
                progressDTO.CountComplitedTask++;
            }

            var progress = _mapper.ToMap<Progress>(progressDTO!);
            long progressId = await _profileRepository.UpdateProgress(progress);

            return progressId;
        }

        /*public async Task<List<long>> UpdateAchievments(ProgressUpdateVm complitedTask)
        {
            //var achievements = await _profileRepository.GetAllAchivements();

            //var type = _profileRepository.GetTypeAchievement(progressVm.ProgressId);
            //var type = complitedTask.TopicTitle.ToLower();
            var complitedAchivements = new List<UserAchievementProgressVm>();

            var listOfAchievementsWithTopicType = _profileRepository.GetAllAchievementsWithTopicType(complitedTask.TopicTitle);// список ачивок по конкретной категории
            var listOfAchievementsWithTopicType2 = _profileRepository.GetAchievementWithUserTopicType(complitedTask.TopicTitle, complitedTask.ProgressId);//user Таблица ачивок ... возврат аичивок по категории (найдёт запись 1)
            
            
            var topicTypeProgress = _profileRepository.IncrementAchievementsByTopicType(listOfAchievementsWithTopicType2); // инриментит нужные денные.. возвращает long progress
            complitedAchivements.Add(CheckAchievements(listOfAchievementsWithTopicType, topicTypeProgress));// возвращает list выполненных ачивок , добавляя его в резалт лист

            var listOfAchievementsWithDifficultType = _profileRepository.FindeAllAchievementsWithDifficultType();
            var listOfAchievementsWithPointType = _profileRepository.FindeAllAchievementsWithPointType();

        }*/
    }
}
