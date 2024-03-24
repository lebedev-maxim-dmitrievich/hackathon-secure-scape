using System.Collections.Generic;

namespace EduPlatform.TaskService.Entities;

public class Topic
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ImageLocation { get; set; } = string.Empty;
    public string IconLocation { get; set; } = string.Empty;

    public List<Theory> Theories { get; set; } = new();
    public List<TaskEntity> Tasks { get; set; } = new();
}
