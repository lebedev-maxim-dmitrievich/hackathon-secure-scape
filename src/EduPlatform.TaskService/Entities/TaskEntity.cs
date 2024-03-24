namespace EduPlatform.TaskService.Entities;

public class TaskEntity
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Exercise { get; set; } = string.Empty;
    public string Answer { get; set; } = string.Empty;
    public string FileLocation { get; set; } = string.Empty;
    public string IconLocation { get; set; } = string.Empty;
    public string Difficult { get; set; } = string.Empty;
    public int Points { get; set; }

    public Topic Topic { get; set; } = null!;
    public long TopicId { get; set; }
}
