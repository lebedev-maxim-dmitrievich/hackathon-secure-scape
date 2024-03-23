using System.Collections.Generic;

namespace EduPlatform.UserService.Entity
{
    public class UserAchievementProgress
    {
        public long UserId { get; set; }
        public long AchievementId { get; set; }
        public long Progress { get; set; }

        public User User { get; set; } = null!;
        public Achievement Achievement { get; set; } = null!;
    }
}
