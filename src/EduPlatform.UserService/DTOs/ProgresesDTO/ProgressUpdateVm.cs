﻿using EduPlatform.UserService.Enum;

namespace EduPlatform.UserService.DTOs.ProgresesDTO
{
    public class ProgressUpdateVm
    {
        public long UserId { get; set; }
        public long TaskId { get; set; }
        public int TaskPoint { get; set; }
        public string TopicTitle { get; set; } = string.Empty;
        public Difficulties TaskDifficult { get; set; }
    }
}
