using EduPlatform.UserService.DTOs.AchievementsDTO;
using System.Collections.Generic;

namespace EduPlatform.UserService.DTOs.ProgresesDTO
{
    public class FullInformationProfileProgressVm
    {
        public BadgeVm BadgeVm { get; set; } = new BadgeVm();
        public List<AchievementVm> AchievementVm { get; set; } = [];
        public ProgressVm ProgressVm { get; set; } = new ProgressVm();
    }
}
