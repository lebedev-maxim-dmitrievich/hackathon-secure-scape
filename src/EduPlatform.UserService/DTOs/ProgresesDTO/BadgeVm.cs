using EduPlatform.UserService.Enum;

namespace EduPlatform.UserService.DTOs.ProgresesDTO
{
    public class BadgeVm
    {
        public string UserName { get; set; } = string.Empty;
        public Levels Level { get; set; }
    }
}
