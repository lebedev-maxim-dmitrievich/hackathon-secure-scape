namespace EduPlatform.TaskService.Entities;

public class Theory
{
    public long Id { get; set; }
    public string Article { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;

    public Topic Topic { get; set; } = null!;
    public long TopicId { get; set; }

}
