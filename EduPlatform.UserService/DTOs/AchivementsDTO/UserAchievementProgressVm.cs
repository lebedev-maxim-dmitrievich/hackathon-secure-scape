namespace EduPlatform.UserService.DTOs.AchivementsDTO
{
    public class UserAchievementProgressVm
    {
        public long UserId { get; set; }
        public string Topic { get; set; } = string.Empty;
        public long ProgressAchievement { get; set; }
    }
}
