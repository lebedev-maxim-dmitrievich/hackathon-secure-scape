namespace EduPlatform.UserService.DTOs.AchievementsDTO
{
    public class UserAchievementProgressVm
    {
        public long UserId { get; set; }
        public long AchievementId { get; set; }
        public string Topic { get; set; } = string.Empty;
        public long ProgressAchievement { get; set; }
    }
}
