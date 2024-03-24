using EduPlatform.TaskService.Auth;
using EduPlatform.TaskService.Db.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IO;
using System.Reflection;

namespace EduPlatform.TaskService;

public class Program
{
    private const string _connectionStringEnvName = "DEFAULT_CONNECTION";

    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services
        .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = AuthOptions.Issuer,
                ValidateAudience = true,
                ValidAudience = AuthOptions.Audience,
                ValidateIssuerSigningKey = true,
                ValidateLifetime = true,
                IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey()
            };
        });
        builder.Services.AddAuthorization();

        //Подключение к бд
        string? connectionString = Environment.GetEnvironmentVariable(_connectionStringEnvName);
        builder.Services.AddDbContext<DbContext, AppDbContext>(options =>
            options.UseNpgsql(connectionString));

        builder.Services.AddControllers();

        // Добавление сваггера с использование xml-документирования
        builder.Services.AddSwaggerGen(config =>
        {
            string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            config.IncludeXmlComments(xmlPath);
        });

        var app = builder.Build();

        // Проверка подключения к бд
        using (var scope = app.Services.CreateScope())
        {
            DbContext dbContext = scope.ServiceProvider.GetRequiredService<DbContext>();
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
        }

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.MapGet("/", () => "Hello from task servie!");

        app.Run();
    }
}
