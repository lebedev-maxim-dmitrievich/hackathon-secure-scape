namespace EduPlatform.TaskService.DTOs;

public class ProgressUpdateDto
{
    public long UserId { get; set; }
    public long TaskId { get; set; }
    public int TaskPoints { get; set; }
    public string TopicTitle { get; set; }
    public string TaskDifficult { get; set; }

    public ProgressUpdateDto(long userId, long taskId, int taskPoints,
        string topicTitle, string taskDifficult)
    {
        UserId = userId;
        TaskId = taskId;
        TaskPoints = taskPoints;
        TopicTitle = topicTitle;
        TaskDifficult = taskDifficult;
    }
}
