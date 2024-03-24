namespace EduPlatform.UserService.DTOs.ProgresesDTO
{
    public class ProgressVm
    {
        public long Id { get; set; }
        public int CountComplitedTask { get; set; }
        public long Scores { get; set; }
        public int RatingPosition { get; set; }
        public int CountComplitedAchievements { get; set; }
    }
}
