using EduPlatform.UserService.Db.Context;
using EduPlatform.UserService.Db.Repositories.Interfaces;
using EduPlatform.UserService.DTOs.AchivementsDTO;
using EduPlatform.UserService.DTOs.ProgresesDTO;
using EduPlatform.UserService.DTOs.TasksDTO;
using EduPlatform.UserService.DTOs.UsersDTO;
using EduPlatform.UserService.Entity;
using EduPlatform.UserService.Mappers.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<AchievementVm>?> GetAchivements(long id)
        {
            var achivements = await _appDbContext.Achievements.AsNoTracking().Where(a => a.Id == id).ToListAsync();

            var achivementsDTO = _mapper.ToMap<Achievement, AchievementVm>(achivements);
            return achivementsDTO;
        }

        public async Task<long> UpdateProgress(Progress progress)
        {
             _appDbContext.Entry(progress).State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();

            return progress.Id;
        }
    }
}
