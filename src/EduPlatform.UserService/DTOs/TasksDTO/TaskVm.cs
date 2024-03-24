using System.ComponentModel.DataAnnotations;

namespace EduPlatform.UserService.DTOs.TasksDTO
{
    public class TaskVm
    {
        [Required]
        public long ExternalTaskId { get; set; }
        [Required]
        public long Experience { get; set; }
        [Required]
        public long ProgressId { get; set; }
    }
}
