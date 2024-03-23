using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace EduPlatform.UserService.Auth;

public static class AuthOptions
{
    static AuthOptions()
    {
        string? envKey = Environment.GetEnvironmentVariable(_keyEnvName);
        if (envKey == null)
        {
            throw new Exception($"В переменной окржения {_keyEnvName} не задано значение");
        }
        else
        {
            _key = envKey;
        }
    }

    private static readonly string _key;
    private const string _keyEnvName = "SECRET_KEY";

    public const string Issuer = "UserService";
    public const string Audience = "SecureScape";

    public const string Salt = "2v042Sgaq1@%11t";

    public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
}
