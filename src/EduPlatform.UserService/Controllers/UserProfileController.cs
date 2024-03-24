using EduPlatform.UserService.DTOs.AchievementsDTO;
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
        /// <response code="404">Прогресс пользователя не найден, пользователь не найден.</response>
        /// <returns></returns>
        [ProducesResponseType(typeof(ProgressVm), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("progress/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetProgresById(long id)
        {
            var progress = await _profileService.GetProgresById(id);

            if (progress == null) return NotFound(new ProblemDetails() { Detail = "Прогресс пользователя не найден, пользователь не найден" });
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
        /// Возврат заданий пользователя
        /// </summary>
        /// <param name="id">Индентификатор пользователя</param>
        /// <response code="200">Задания найдены, возвращает список выполненных заданий.</response>
        /// <response code="404">Задания не найдены, пользователь не найден.</response>
        /// <returns></returns>
        [ProducesResponseType(typeof(List<TaskVm>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("allTasksUser/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetAllTasksByUserId(long id)
        {
            var tasks = await _profileService.GetAllTasksByUserId(id);

            if (tasks == null) return NotFound(new ProblemDetails() { Detail = "Задания не найдены, пользователь не найден" });
            return Ok(tasks);
        }

        /// <summary>
        /// Возврат достижений пользователя
        /// </summary>
        /// <param name="id">Индентификатор пользователя</param>
        /// <response code="200">Достижения найдены, возвращает список достижений пользователя.</response>
        /// <response code="404">Достижения не найдены, пользователь не найден.</response>
        /// <returns></returns>
        [ProducesResponseType(typeof(List<UserAchievementProgressVm>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("allUserAchievements/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetUserAchievements(long id)
        {
            var achivements = await _profileService.GetUserAchievements(id);

            if (achivements == null) return NotFound(new ProblemDetails() { Detail = "Достижения не найдены, пользователь не найден" });
            return Ok(achivements);
        }

        /// <summary>
        /// Возвраn рейтинга пользователей
        /// </summary>
        /// <param name="count">Размер рейтинга</param>
        /// <response code="200">Сформирован рейтин, возвращает рейтинг пользователей.</response>
        /// <returns></returns>
        [ProducesResponseType(typeof(List<RatingProgressVm>), StatusCodes.Status200OK)]
        [Route("getRating/{count}")]
        [HttpGet]
        public async Task<IActionResult> GetRatingUsers(int count)
        {
            var rating = await _profileService.GetRatingUsers(count);

            return Ok(rating);
        }

        /// <summary>
        /// Возврат полной информации прогресса пользователя
        /// </summary>
        /// <param name="id">Индентификатор пользователя</param>
        /// <response code="200">Сформирован рейтин, возвращает рейтинг пользователей.</response>
        /// <returns></returns>
        [Route("FullProfileInformation/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetFullInformationProfileProgress(long id)
        {
            var information = await _profileService.GetFullInformationProgress(id);

            return Ok(information);
        }

        /// <summary>
        /// Обновление прогресса пользователя
        /// </summary>
        /// <param name="progressVm">Объект с новыми данными для обновления</param>
        /// <response code="200">Прогресс обновлён, возвращает id прогресса</response>
        /// <returns></returns>
        [ProducesResponseType(typeof(long), StatusCodes.Status200OK)]
        [Route("updateProgress")]
        [HttpPut]
        public async Task<IActionResult> UpdateProgress(ProgressUpdateVm progressVm)
        {
            long progressId = await _profileService.UpdateProgress(progressVm);

            return Ok(progressId);
        }
    }
}
