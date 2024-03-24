using EduPlatform.UserService.DTOs.AchievementsDTO;
using EduPlatform.UserService.DTOs.ProgresesDTO;
using EduPlatform.UserService.DTOs.TasksDTO;
using EduPlatform.UserService.DTOs.UsersDTO;
using EduPlatform.UserService.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduPlatform.UserService.Db.Repositories.Interfaces;

public interface IProfileRepository
{
    public Task<bool> CheckUser(long id);

    public Task<long> AddTask(TaskEntity task);

    public Task<ProgressVm?> GetProgress(long id);

    public Task<Progress> GetFullProgress(long id);

    public Task<UserVm?> GetUser(long id);

    public Task<List<ProgressVm>?> GetAllUsersProgress();

    public Task<List<TaskVm>?> GetTasksUser(long id);

    public Task<List<AchievementVm>> GetAllAchivements();

    public Task<List<Achievement>> GetFullInformationUserAchivements(long id);

    public Task<List<UserAchievementProgressVm>> GetUserAchivements(long id);

    public Task<string> GetTypeAchievement(long id);

    public Task<List<AchievementVm>> GetAllAchievementsWithTopicType(string category);

    public Task<UserAchievementProgressVm> GetAchievementWithUserTopicType(string category, long id);

    public Task<int> GetRatingPositionUser(long id);

    public Task<long> UpdateProgress(Progress progress);

    public Task<List<RatingProgressVm>?> CreateRatingList(int count);

    //public Task<long> UpdateIncrementAchievementsByTopicType(UserAchievementProgressVm achievements);

}
