﻿using System.Collections.Generic;

namespace EduPlatform.UserService.Entity
{
    public class Progress
    {
        public long Id { get; set; }
        public long Scores { get; set; }
        public int CountComplitedTask { get; set; } = 0;

        public List<TaskEntity> AllTasks { get; set; } = new();
        public List<Achievement> AllAchivements { get; set; } = new();

        public User User { get; set; } = null!;
    }
}
