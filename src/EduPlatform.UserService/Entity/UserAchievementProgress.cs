using System.Collections.Generic;

namespace EduPlatform.UserService.Entity
{
    public class UserAchievementProgress
    {
        public long UserId { get; set; }
        public long AchievementId { get; set; }
        public string Topic { get; set; } = string.Empty;
        public long ProgressAchievement { get; set; } = 0;

        public User User { get; set; } = null!;
        public Achievement Achievement { get; set; } = null!;
    }
}
