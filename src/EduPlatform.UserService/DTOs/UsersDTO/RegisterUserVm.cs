using System.ComponentModel.DataAnnotations;
namespace EduPlatform.UserService.DTOs.UsersDTO;

public class RegisterUserVm
{
    [Required]
    public string UserName { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;
    [Required]
    public string Email { get; set; } = string.Empty;
}
