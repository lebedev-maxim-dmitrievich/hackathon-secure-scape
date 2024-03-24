using EduPlatform.TaskService.DTOs;
using EduPlatform.TaskService.Enums;
using EduPlatform.TaskService.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EduPlatform.TaskService.Controllers;

[Route("api/[controller]")]
public class TaskController : ControllerBase
{
    private readonly ITaskService _taskService;

    public TaskController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTask(int id)
    {
        TaskVm task = await _taskService.GetTaskById(id);

        return Ok(task);
    }

    [HttpGet()]
    public async Task<IActionResult> GetTasks(string? topicName, Difficulties? difficult)
    {
        var tasks = await _taskService.GetTasks(topicName, difficult.ToString());

        return Ok(tasks);
    }
}
