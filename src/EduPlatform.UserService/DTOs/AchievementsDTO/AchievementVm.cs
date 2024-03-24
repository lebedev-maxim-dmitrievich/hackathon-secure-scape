using EduPlatform.UserService.Enum;

namespace EduPlatform.UserService.DTOs.AchievementsDTO
{
    public class AchievementVm
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string RelativeIconLocation { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public Rarities Rarity { get; set; }
    }
}
