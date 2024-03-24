using EduPlatform.TaskService.Enums;

namespace EduPlatform.TaskService.Entities;

public class TaskEntity
{
    public long Id { get; set; }
    public string Exercise { get; set; } = string.Empty;
    public string FileLocation { get; set; } = string.Empty;
    public string Answer { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Difficulties Difficult { get; set; }
    public int Points { get; set; }

    public Topic Topic { get; set; } = null!;
    public long TopicId { get; set; }
}
