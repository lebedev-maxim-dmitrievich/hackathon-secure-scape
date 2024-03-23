using System.ComponentModel.DataAnnotations.Schema;

namespace EduPlatform.UserService.Entity
{
    public class TaskEntity
    {
        public long Id { get; set; }
        public long ExternalTaskId { get; set; }
        public long ProgressId { get; set; }

        [NotMapped]
        public long Experience { get; set; }
        public Progress Progress { get; set; } = null!;
    }
}
