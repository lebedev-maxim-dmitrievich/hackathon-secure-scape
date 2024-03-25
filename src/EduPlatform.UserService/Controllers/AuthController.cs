using EduPlatform.UserService.DTOs.UsersDTO;
using EduPlatform.UserService.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EduPlatform.UserService.Controllers;

/// <summary>
/// Предоставляет функционал аутентификации пользователя.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    /// <summary>
    /// Регистрация нового пользователя.
    /// </summary>
    /// <param name="registerUserVm">Объект для регистрации пользователя.</param>
    /// <response code="200">Пользователь зарегистрирован, возвращает его id.</response>
    /// <response code="400">Пользователь с таким UserName уже существует.</response>
    [ProducesResponseType(typeof(long), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterUserVm registerUserVm)
    {
        long? id = await _authService.Register(registerUserVm);

        if (id == null)
        {
            return BadRequest(new ProblemDetails() 
            { Detail = "Пользователь с таким никнеймом уже существует" });
        }

        return Ok(id);
    }

    /// <summary>
    /// Вход пользователя. Возвращает JWT-токен.
    /// </summary>
    /// <param name="loginUserVm">Объект для входа пользователя.</param>
    /// <response code="200">Вход выполнен успешно, возвращает структура данных с id и jwt-токеном.</response>
    /// <response code="400">Возвращается если введён неправильный логин или пароль.</response>
    [ProducesResponseType(typeof(LoginAnswerMv), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginUserVm loginUserVm)
    {
        LoginAnswerMv? loginAnswerVm = await _authService.Login(loginUserVm);
        if (loginAnswerVm != null)
        {
            return Ok(loginAnswerVm);
        }

        return BadRequest(new ProblemDetails()
        { Detail = "Неправильный логин или пароль" });
    }
}
