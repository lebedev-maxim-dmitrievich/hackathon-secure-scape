using EduPlatform.TaskService.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IO;
using System.Reflection;

namespace EduPlatform.TaskService
{
    public class Program
    {
        private const string _connectionStringEnvName = "TASKS_DB_CONNECTION";

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

            // ����������� � ��
            //string? connectionString = Environment.GetEnvironmentVariable(_connectionStringEnvName);
            //builder.Services.AddDbContext<DbContext, AppDbContext>(options =>
            //    options.UseNpgsql(connectionString));

            builder.Services.AddControllers();

            // ���������� �������� � ������������� xml-����������������
            builder.Services.AddSwaggerGen(config =>
            {
                string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                config.IncludeXmlComments(xmlPath);
            });

            var app = builder.Build();

            //// �������� ����������� � ��
            //using (var scope = app.Services.CreateScope())
            //{
            //    DbContext dbContext = scope.ServiceProvider.GetRequiredService<DbContext>();
            //    //dbContext.Database.EnsureDeleted();
            //    dbContext.Database.EnsureCreated();
            //}

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
}
