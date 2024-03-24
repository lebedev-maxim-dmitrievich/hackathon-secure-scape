using System.Collections.Generic;

namespace EduPlatform.TaskService.DTOs;

public class TasksVm
{
    List<TaskPresentationVm> Tasks { get; set; }

    public TasksVm(List<TaskPresentationVm> tasks)
    {
        Tasks = tasks;
    }
}
