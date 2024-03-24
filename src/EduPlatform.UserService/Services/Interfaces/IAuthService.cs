using EduPlatform.UserService.DTOs.UsersDTO;
using System.Threading.Tasks;

namespace EduPlatform.UserService.Services.Interfaces;

public interface IAuthService
{
    public Task<string?> Login(LoginUserVm loginUserVm);

    public Task<long?> Register(RegisterUserVm registerUserVm);
}
