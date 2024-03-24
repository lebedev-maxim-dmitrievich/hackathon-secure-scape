using EduPlatform.TaskService.Entities;
using System.Collections.Generic;

namespace EduPlatform.TaskService.DTOs;

public class TopicsVm
{
    public List<Topic> Topics { get; set; }

    public TopicsVm(List<Topic> topics)
    {
        Topics = topics;
    }
}
