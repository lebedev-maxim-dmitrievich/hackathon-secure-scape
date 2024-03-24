using EduPlatform.TaskService.Enums;

namespace EduPlatform.TaskService.DTOs;

public class TaskVm
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Exercise { get; set; } = string.Empty;
    public string FileLocation { get; set; } = string.Empty;
    public string IconLocation { get; set; } = string.Empty;
    public string Difficult { get; set; }
    public int Points { get; set; }

    public TaskVm(long id, string title, string desctiption,
        string exercise, string fileLocation, string iconLocation,
        string difficult, int points)
    {
        Id = id;
        Title = title;
        Description = desctiption;
        Exercise = exercise;
        FileLocation = fileLocation;
        IconLocation = iconLocation;
        Difficult = difficult;
        Points = points;
    }
}
