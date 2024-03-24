using EduPlatform.UserService.Entity;
using EduPlatform.UserService.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Reflection.Emit;

namespace EduPlatform.UserService.Db.Context;

public class AppDbContext : DbContext
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<Progress> Progreses => Set<Progress>();
    public DbSet<TaskEntity> Tasks => Set<TaskEntity>();
    public DbSet<Achievement> Achievements => Set<Achievement>();
    public DbSet<UserAchievementProgress> UsersAchievementsProgress => Set<UserAchievementProgress>();

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) {}

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<User>()
        .HasMany(e => e.Achievements)
        .WithMany(e => e.Users)
        .UsingEntity<UserAchievementProgress>(
            l => l.HasOne(e => e.Achievement).WithMany(e => e.UsersAchievementsProgress).HasForeignKey(e => e.AchievementId),
            r => r.HasOne(e => e.User).WithMany(e => e.UsersAchievementsProgress).HasForeignKey(e => e.UserId));

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
            Scores = 10,
            CountComplitedTask = 2,
        },

        new Progress
        {
            Id = 2,
            Scores = 20,
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

        builder.Entity<Achievement>().HasData(new Achievement
        {
            Id = 1,
            Title = "Master Hacker",
            Description = "Successfully hack 100 systems",
            RelativeIconLocation = Path.Combine("media", "images", "achievements", "Master-Hacker.png"),
            Requirement = 100,
            Rarity = Rarities.Mythical
        },

        new Achievement
        {
            Id = 2,
            Title = "Security Analyst",
            Description = "Complete 50 security assessments",
            RelativeIconLocation = Path.Combine("media", "images", "achievements", "Security-Analyst.png"),
            Requirement = 50,
            Rarity = Rarities.Rare
        });

        builder.Entity<UserAchievementProgress>().HasData(new UserAchievementProgress
        {
            UserId = 1,
            AchievementId = 1,
            Topic = AchievementsType.Cryptography,
            ProgressAchievement = 1
        },

        new UserAchievementProgress
        {
            UserId = 1,
            AchievementId = 2,
            Topic = AchievementsType.Beginner,
            ProgressAchievement = 20
        },

        new UserAchievementProgress
        {
            UserId = 2,
            AchievementId = 2,
            Topic = AchievementsType.Advanced,
            ProgressAchievement = 100
        });

        base.OnModelCreating(builder);
    }
}
