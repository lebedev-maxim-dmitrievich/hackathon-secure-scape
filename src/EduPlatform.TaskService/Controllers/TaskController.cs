using EduPlatform.TaskService.DTOs;
using EduPlatform.TaskService.Enums;
using EduPlatform.TaskService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
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

    /// <summary>
    /// Отправка задания на проверку.
    /// </summary>
    /// <param name="answerDto">Структура для передачи ответа на задачу.</param>
    /// <response code="200">Ответ о выполнении задачи.</response>
    /// <response code="400">Не удалось получить id пользователя из jwt-токена.</response>
    /// <response code="404">Задачи с указанным id не существует.</response>
    [ProducesResponseType(typeof(AnswerEstimation), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpPost("answer")]
    [Authorize]
    public async Task<IActionResult> GiveAnswer([FromBody] GiveAnswerDTO answerDto)
    {
        var estimation = new AnswerEstimation();

        if (await _taskService.CheckAnswer(answerDto))
        {
            estimation.Correct = true;
            string? userId = User.FindFirst("id")?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest(new ProblemDetails 
                { 
                    Detail = "Не удалось получить id пользователя"
                });
            }
            await _taskService.UpdateUserProgress(long.Parse(userId), answerDto.TaskId);
        }

        return Ok(estimation);
    }
}
