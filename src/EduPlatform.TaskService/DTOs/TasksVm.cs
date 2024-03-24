using System.Collections.Generic;

namespace EduPlatform.TaskService.DTOs;

public class TasksVm
{
    public List<TaskVm> Tasks { get; set; }

    public TasksVm(List<TaskVm> tasks)
    {
        Tasks = tasks;
    }
}
