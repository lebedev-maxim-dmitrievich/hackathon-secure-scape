using EduPlatform.UserService.Auth;
using EduPlatform.UserService.DTOs.UsersDTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System;
using System.Threading.Tasks;
using EduPlatform.UserService.Db.Repositories.Interfaces;
using EduPlatform.UserService.Entity;
using EduPlatform.UserService.Services.Interfaces;

namespace EduPlatform.UserService.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher<User> _passwordHasher;

    public AuthService(IUserRepository userRepository,
        IPasswordHasher<User> passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<LoginAnswerMv?> Login(LoginUserVm loginUserVm)
    {
        var user = await _userRepository.GetUserByUsername(loginUserVm.UserName);

        if (user != null)
        {
            var saltedPasword = loginUserVm.Password + AuthOptions.Salt;

            var passwordHash = _passwordHasher.VerifyHashedPassword(user,
                user.PasswordHash, saltedPasword);
            if (passwordHash == PasswordVerificationResult.Success)
            {
                var claims = new List<Claim>
                {
                    new ("id", user.Id.ToString()),
                    new ("name", user.UserName),
                    new ("email", user.Email),
                    new ("role", user?.Role?.Name ?? "")
                };

                var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.Issuer,
                    audience: AuthOptions.Audience,
                    claims: claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromDays(3)),
                    notBefore: DateTime.UtcNow,
                    signingCredentials: new SigningCredentials(
                        AuthOptions.GetSymmetricSecurityKey(),
                        SecurityAlgorithms.HmacSha256)
                    );

                return new LoginAnswerMv()
                {
                    Id = user.Id,
                    JwtToken = new JwtSecurityTokenHandler().WriteToken(jwt)
                };
            }
        }
        return null;
    }

    public async Task<long?> Register(RegisterUserVm registerUserVm)
    {
        var user = await _userRepository.GetUserByUsername(registerUserVm.UserName);
        if (user != null)
        {
            return null;
        }

        string saltedPassword = registerUserVm.Password + AuthOptions.Salt;
        user = new User()
        {
            UserName = registerUserVm.UserName,
            Email = registerUserVm.Email,
            Progress = new Progress()
        };
        user.PasswordHash = _passwordHasher.HashPassword(user, saltedPassword);

        long id = await _userRepository.AddAsync(user);

        return id;
    }
}
