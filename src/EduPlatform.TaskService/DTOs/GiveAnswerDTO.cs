using System.ComponentModel.DataAnnotations;

namespace EduPlatform.TaskService.DTOs;

public class GiveAnswerDTO
{
    [Required]
    public long TaskId { get; set; }
    [Required]
    public string Answer { get; set; } = string.Empty;
}
