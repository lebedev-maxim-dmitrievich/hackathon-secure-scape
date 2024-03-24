using EduPlatform.TaskService.DTOs;
using EduPlatform.TaskService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EduPlatform.TaskService.Controllers;

/// <summary>
/// Предоставляет функционал работы с темами.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class TopicsController : ControllerBase
{
    private readonly ITopicService _topicService;


    public TopicsController(ITopicService topicService)
    {
        _topicService = topicService;
    }

    /// <summary>
    /// Получение списка тем.
    /// </summary>
    /// <response code="200">Возвращает список тем.</response>
    [ProducesResponseType(typeof(TopicsVm), StatusCodes.Status200OK)]
    [HttpGet]
    public async Task<IActionResult> GetAllTopics()
    {
        var topics = await _topicService.GetTopics();

        return Ok(topics);
    }
}
