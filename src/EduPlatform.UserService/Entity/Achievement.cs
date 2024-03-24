using EduPlatform.UserService.Enum;
using System.Collections.Generic;

namespace EduPlatform.UserService.Entity
{
    public class Achievement
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string RelativeIconLocation { get; set; } = string.Empty;
        public AchievementsType Type { get; set; }
        public int Requirement { get; set; }
        public Rarities Rarity { get; set; }

        public List<User> Users { get; } = [];
        public List<UserAchievementProgress> UsersAchievementsProgress { get; } = [];
    }
}
