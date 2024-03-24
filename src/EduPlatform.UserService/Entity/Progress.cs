using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduPlatform.UserService.Entity
{
    public class Progress
    {
        public long Id { get; set; }
        public long Scores { get; set; } = 0;
        public int CountComplitedTask { get; set; } = 0;
        [NotMapped]
        public int RatingPosition { get; set; } = -1;
        [NotMapped]
        public int CountComplitedAchievements { get; set; } = 0;

        public List<TaskEntity> AllTasks { get; set; } = [];
        [NotMapped]
        public List<Achievement> AllAchivements { get; set; } = [];

        public User User { get; set; } = null!;
    }
}
