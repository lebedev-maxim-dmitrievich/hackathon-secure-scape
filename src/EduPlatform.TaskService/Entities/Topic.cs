using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EduPlatform.TaskService.Entities;

public class Topic
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ImageLocation { get; set; } = string.Empty;

    [JsonIgnore]
    public List<Theory> Theories { get; set; } = new();
    [JsonIgnore]
    public List<TaskEntity> Tasks { get; set; } = new();
}
