namespace EduPlatform.TaskService.DTOs;

public class TaskVm
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Topic { get; set; }
    public string FileLocation { get; set; }
    public string IconLocation { get; set; }
    public string Difficult { get; set; }
    public int Points { get; set; }

    public TaskVm(long id, string title, string desctiption,
        string topic, string fileLocation, string iconLocation,
        string difficult, int points)
    {
        Id = id;
        Title = title;
        Description = desctiption;
        Topic = topic;
        FileLocation = fileLocation;
        IconLocation = iconLocation;
        Difficult = difficult;
        Points = points;
    }
}
