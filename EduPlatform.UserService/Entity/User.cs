using EduPlatform.UserService.Enum;
using System.Collections.Generic;

namespace EduPlatform.UserService.Entity
{
    public class User
    {
        public long Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public List<Achievement> Achievements { get; } = [];
        public List<UserAchievementProgress> UsersAchievementsProgress { get; } = [];

        public long RoleId { get; set; } = 2;
        public Role? Role { get; set; }

        public Progress? Progress { get; set; }
    }
}