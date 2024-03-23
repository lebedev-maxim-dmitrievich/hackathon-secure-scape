namespace EduPlatform.UserService.DTOs.AchivementsDTO
{
    public class AchievementVm
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string RelativeIconLocation { get; set; } = string.Empty;
        public int Rarity { get; set; }
    }
}
