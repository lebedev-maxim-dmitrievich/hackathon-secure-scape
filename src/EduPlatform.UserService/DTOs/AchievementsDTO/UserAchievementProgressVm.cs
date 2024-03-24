using EduPlatform.UserService.Enum;

namespace EduPlatform.UserService.DTOs.AchievementsDTO
{
    public class UserAchievementProgressVm
    {
        public long UserId { get; set; }
        public long AchievementId { get; set; }
        public AchievementsType Topic { get; set; }
        public long ProgressAchievement { get; set; }
    }
}
