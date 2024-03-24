using EduPlatform.TaskService.Enums;

namespace EduPlatform.TaskService.DTOs;
public class TaskPresentationVm
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Difficult { get; set; }
    public string IconLocation { get; set; }

    public TaskPresentationVm(long id, string title, string desctiption,
        string difficult, string iconLocation)
    {
        Id = id;
        Title = title;
        Description = desctiption;
        Difficult = difficult;
        IconLocation = iconLocation;
    }
}
