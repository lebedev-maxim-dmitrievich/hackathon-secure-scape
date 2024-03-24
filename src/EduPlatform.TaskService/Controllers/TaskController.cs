using EduPlatform.TaskService.DTOs;
using EduPlatform.TaskService.Enums;
using EduPlatform.TaskService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EduPlatform.TaskService.Controllers;

/// <summary>
/// Предоставляет функционал работы с задачами.
/// </summary>
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
    private readonly ITaskService _taskService;

    public TaskController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    /// <summary>
    /// Получение всей информации о задаче.
    /// </summary>
    /// <param name="id">Идентификатор задачи.</param>
    /// <response code="200">Задача в json, соответствующая id.</response>
    /// <response code="404">Задачи с таким id нет.</response>
    [ProducesResponseType(typeof(TaskVm), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetTask(int id)
    {
        TaskVm task = await _taskService.GetTaskById(id);

        return Ok(task);
    }

    /// <summary>
    /// Получение списка задач с коротким описанием.
    /// </summary>
    /// <param name="topicName">Название темы, для применения фильтра по темам.</param>
    /// <param name="difficult">Сложность задач, для применения фильтра по сложности.</param>
    /// <response code="200">Список задач.</response>
    [ProducesResponseType(typeof(TasksVm), StatusCodes.Status200OK)]
    [HttpGet()]
    public async Task<IActionResult> GetTasks(string? topicName, Difficulties? difficult)
    {
        var tasks = await _taskService.GetTasks(topicName, difficult.ToString());

        return Ok(tasks);
    }

    [HttpPost("answer")]
    [Authorize]
    public async Task<IActionResult> GiveAnswer(GiveAnswerDTO answerDto)
    {
        //_taskService.CheckAnswer();

        string? userId = User.FindFirst("id")?.Value;
        //TODO: сделать обращение к сервису пользователя
        return Ok(userId);
    }
}
