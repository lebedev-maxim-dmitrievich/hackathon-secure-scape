using EduPlatform.UserService.Db.Context;
using EduPlatform.UserService.Db.Repositories.Interfaces;
using EduPlatform.UserService.DTOs.AchievementsDTO;
using EduPlatform.UserService.DTOs.ProgresesDTO;
using EduPlatform.UserService.DTOs.TasksDTO;
using EduPlatform.UserService.DTOs.UsersDTO;
using EduPlatform.UserService.Entity;
using EduPlatform.UserService.Enum;
using EduPlatform.UserService.Mappers.Interfaces;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EduPlatform.UserService.Db.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly AppDbContext _appDbContext;
        private ISimpleMapper _mapper;

        public ProfileRepository(AppDbContext context, ISimpleMapper mapper) 
        {
            _appDbContext = context;   
            _mapper = mapper;
        }

        public async Task<bool> CheckUser(long id)
        {
            var user = await _appDbContext.Users.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);

            if (user != null) return true;

            return false;
        }

        public async Task<long> AddTask(TaskEntity task)
        {
            await _appDbContext.Tasks.AddAsync(task);
            await _appDbContext.SaveChangesAsync();

            return task.Id;
        }

        public async Task<ProgressVm?> GetProgress(long id)
        {
            var progressEntity = await _appDbContext.Progreses.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);

            var progressDTO = progressEntity == null ? null : _mapper.ToMap<ProgressVm>(progressEntity);
            return progressDTO;
        }
        public async Task<Progress> GetFullProgress(long id)
        {
            var progress = await _appDbContext.Progreses.AsNoTracking().Include(p => p.User)
                .Include(p => p.AllTasks).FirstAsync(p => p.Id == id);

            return progress;
        }

        public async Task<UserVm?> GetUser(long id)
        {
            var userEntity = await _appDbContext.Users.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);

            var userDTO = userEntity == null ? null : _mapper.ToMap<UserVm>(userEntity);
            return userDTO;
        }

        public async Task<List<TaskVm>?> GetTasksUser(long id)
        {
            var tasksEntity = await _appDbContext.Tasks.AsNoTracking().Where(t => t.ProgressId == id).ToListAsync();

            var tasksDTO = _mapper.ToMap<TaskEntity, TaskVm>(tasksEntity);
            return tasksDTO;
        }

        public async Task<List<AchievementVm>> GetAllAchivements()
        {
            var achievements = await _appDbContext.Achievements.AsNoTracking().ToListAsync();

            var achievementsDTO = _mapper.ToMap<Achievement, AchievementVm>(achievements);
            return achievementsDTO;
        }

        public async Task<List<UserAchievementProgressVm>> GetUserAchivements(long id)
        {
            var achievements = await _appDbContext.UsersAchievementsProgress.AsNoTracking().Where(a => a.UserId == id).ToListAsync();

            var achievementsDTO = _mapper.ToMap<UserAchievementProgress, UserAchievementProgressVm>(achievements);
            return achievementsDTO;
        }
        public async Task<List<Achievement>> GetFullInformationUserAchivements(long id)
        {
            var allAchievments = await _appDbContext.Achievements.AsNoTracking().Include(a => a.Users).Include(a=> a.UsersAchievementsProgress).ToListAsync();

            return allAchievments;
        }

        public async Task<string> GetTypeAchievement(long id)
        {
            var achievement = await _appDbContext.Achievements.AsNoTracking().Where(t => t.Id == id).FirstAsync();
            var typeAchievement = achievement.Type.ToString();

            return typeAchievement;
        }
        public async Task<List<AchievementVm>> GetAllAchievementsWithTopicType(string category)
        {
            var achievements = await _appDbContext.Achievements.AsNoTracking().Where(a => a.Type.ToString() == category).ToListAsync();

            var achievementsDTO = _mapper.ToMap<Achievement, AchievementVm>(achievements);
            return achievementsDTO;
        }

        public async Task<UserAchievementProgressVm> GetAchievementWithUserTopicType(string category, long id)
        {
            var userAchievements = await GetUserAchivements(id);
            var achievement = userAchievements.Where(u => u.Topic.ToString() == category).First();

            return achievement;
        }
        public async Task<List<ProgressVm>?> GetAllUsersProgress()
        {
            var progress = await _appDbContext.Progreses.AsNoTracking().ToListAsync();

            var progressDTO = _mapper.ToMap<Progress, ProgressVm>(progress);

            return progressDTO;
        }
        public async Task<int> GetRatingPositionUser(long id)
        {
            var rating = await _appDbContext.Progreses.AsNoTracking().OrderByDescending(p => p.Scores).ToListAsync();
            
            var userRating = rating.IndexOf(rating.FirstOrDefault(p => p.Id == id)!) + 1;

            return userRating;
        }

        public async Task<long> UpdateProgress(Progress progress)
        {
             _appDbContext.Entry(progress).State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();

            return progress.Id;
        }

        public async Task<List<RatingProgressVm>?> CreateRatingList(int count)
        {
            var resultRating = new List<RatingProgressVm>();
            var usersProgress = await _appDbContext.Progreses.Include(p => p.User).OrderByDescending(p => p.Scores).Take(count).ToListAsync();

            foreach (var progress in usersProgress)
            {
                var rating = new RatingProgressVm()
                {
                    UserId = progress.User.Id,
                    UserName = progress.User.UserName,
                    Scores = progress.Scores
                };

                resultRating.Add(rating);
            }

            return resultRating;
        }

        /*public Task<long> UpdateIncrementAchievementsByTopicType(UserAchievementProgressVm achievement)
        {
            var usetAchievement = new UserAchievementProgressVm() 
            { 
                Topic = achievement.Topic ,
                ProgressAchievement = achievement.ProgressAchievement,
            };
           
        }*/
    }
}
