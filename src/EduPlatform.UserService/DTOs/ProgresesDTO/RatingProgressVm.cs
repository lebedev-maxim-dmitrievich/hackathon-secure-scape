namespace EduPlatform.UserService.DTOs.ProgresesDTO
{
    public class RatingProgressVm
    {
        public long UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public long Scores { get; set; } = 0;
    }
}
