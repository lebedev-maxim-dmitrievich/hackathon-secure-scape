using EduPlatform.UserService.DTOs.UsersDTO;
using System.Threading.Tasks;

namespace EduPlatform.UserService.Services.Interfaces;

public interface IAuthService
{
    public Task<LoginAnswerMv> Login(LoginUserVm loginUserVm);

    public Task<long?> Register(RegisterUserVm registerUserVm);
}
