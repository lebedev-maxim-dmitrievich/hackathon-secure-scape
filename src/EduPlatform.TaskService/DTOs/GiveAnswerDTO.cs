namespace EduPlatform.TaskService.DTOs;

public class GiveAnswerDTO
{
    public long TaskId { get; set; }
    public string Answer { get; set; } = string.Empty;
}
