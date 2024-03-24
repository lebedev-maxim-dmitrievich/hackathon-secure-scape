using EduPlatform.UserService.DTOs.ProgresesDTO;
using EduPlatform.UserService.DTOs.TasksDTO;
using EduPlatform.UserService.DTOs.UsersDTO;
using EduPlatform.UserService.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduPlatform.UserService.Controllers
{
    /// <summary>
    /// Предоставляет функционал для работы user профиля
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class UserProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;

        public UserProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        /// <summary>
        /// Возврат прогресса пользователя
        /// </summary>
        /// <param name="id">Индентификатор пользователя</param>
        /// <response code="200">Прогресс найден, возвращает прогресс пользователя.</response>
        /// <response code="404">Прогресс пользователя не найден.</response>
        /// <returns></returns>
        [ProducesResponseType(typeof(ProgressVm), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("progress/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetProgresById(long id)
        {
            var progress = await _profileService.GetProgresById(id);

            if (progress == null) return NotFound(new ProblemDetails() { Detail = "Прогресс пользователя не найден" });
            return Ok(progress);
        }

        /// <summary>
        /// Возврат пользователя
        /// </summary>
        /// <param name="id">Индентификатор пользователя</param>
        /// <response code="200">Пользователь найден, возвращает пользователя.</response>
        /// <response code="404">Пользователь не найден.</response>
        /// <returns></returns>
        [ProducesResponseType(typeof(UserVm), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("user/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetUserById(long id)
        {
            var user = await _profileService.GetUserById(id);

            if (user == null) return NotFound(new ProblemDetails() { Detail = "Пользователь не найден" });
            return Ok(user);
        }

        /// <summary>
        /// Возврат задач пользователя
        /// </summary>
        /// <param name="id">Индентификатор пользователя</param>
        /// <response code="200">Задания найдены, возвращает список выполненных заданий.</response>
        /// <response code="404">Задания не найдены.</response>
        /// <returns></returns>
        [ProducesResponseType(typeof(List<TaskVm>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("allTasksUser/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetAllTasksByUserId(long id)
        {
            var tasks = await _profileService.GetAllTasksByUserId(id);

            if (tasks == null) return NotFound(new ProblemDetails() { Detail = "Задания не найдены" });
            return Ok(tasks);
        }

        /// <summary>
        /// Добавление задачи в прогресс пользователя 
        /// </summary>
        /// <param name="taskVm">Объект для добавления задания</param>
        /// <response code="200">Задание добавлено, возвращает id задачи.</response>
        /// <response code="400">Нет задания для добавления.</response>
        /// <returns></returns>
        [ProducesResponseType(typeof(long), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("addTask")]
        [HttpPost]
        public async Task<IActionResult> AddTaskInProgress(TaskVm taskVm)
        {
            if (taskVm == null) return BadRequest(new ProblemDetails() { Detail = "Нет задания для добавления" });

            long? id = await _profileService.AddTaskInProgress(taskVm);
            return Ok(id);
        }
    }
}
