using EduPlatform.UserService.Entity;
using Microsoft.EntityFrameworkCore;

namespace EduPlatform.UserService.Db.Context;

public class AppDbContext : DbContext
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<Progress> Progreses => Set<Progress>();
    public DbSet<TaskEntity> Tasks => Set<TaskEntity>();

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) {}

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<User>()
            .HasOne(u => u.Progress)
            .WithOne(u => u.User)
            .HasForeignKey<Progress>(u => u.Id)
            .IsRequired();

        builder.Entity<Role>().HasData(
            new Role
            {
                Id = 1,
                Name = Enum.Roles.Admin.ToString(),
            },
            new Role
            {
                Id = 2,
                Name = Enum.Roles.User.ToString()
            });

        builder.Entity<User>().HasData(new User
        {
            Id = 1,
            RoleId = 1,
            UserName = "Test1",
            // пароль - string
            PasswordHash = "AQAAAAIAAYagAAAAEIkUamzDMfkTuzbrabohW9DV6Z+q0n9qpcnIVLQsK4NAJ4kolcNcefhISei6YH/Yzw==",
            Email = "Test1"
        },
        
        new User
        {
            Id = 2,
            RoleId = 2,
            UserName = "Test2",
            PasswordHash = "AQAAAAIAAYagAAAAEIkUamzDMfkTuzbrabohW9DV6Z+q0n9qpcnIVLQsK4NAJ4kolcNcefhISei6YH/Yzw==",
            Email = "Test2"
        });

        builder.Entity<Progress>().HasData(new Progress
        {
            Id = 1,
            Scores = 0,
            CountComplitedTask = 2,
        },

        new Progress
        {
            Id = 2,
            Scores = 0,
            CountComplitedTask = 1,
        });

        builder.Entity<TaskEntity>().HasData(new TaskEntity
        {
            Id = 1,
            ExternalTaskId = 1,
            ProgressId = 1
        },

        new TaskEntity
        {
            Id = 2,
            ExternalTaskId = 2,
            ProgressId = 1
        },

        new TaskEntity
        {
            Id = 3,
            ExternalTaskId = 1,
            ProgressId = 2
        });

        base.OnModelCreating(builder);
    }
}
