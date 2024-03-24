using EduPlatform.TaskService.Entities;
using EduPlatform.TaskService.Enums;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace EduPlatform.TaskService.Db.Context;

public class AppDbContext : DbContext
{
    public DbSet<TaskEntity> Tasks => Set<TaskEntity>();
    public DbSet<Theory> Theories => Set<Theory>();
    public DbSet<Topic> Topics => Set<Topic>();


    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Topic>().HasData(
            new Topic
            {
                Id = 1,
                Title = "Реверс-инжиниринг",
                Description = "Реверсивный инжиниринг (реверс инжиниринг, обратное проектирование, reverse-engineering)",
                ImageLocation = Path.Combine("media", "images", "topics", "reverse-engineering.png")
            });

        builder.Entity<Theory>().HasData(
            new Theory
            {
                Id = 1,
                Article = "*8рп * пыпфщ",
                Title = "Реверс-инжиниринг - это",
                TopicId = 1
            });

        builder.Entity<TaskEntity>().HasData(
            new TaskEntity
            {
                Id = 1,
                Title = "Назваине 1",
                Description = "Описание чего-о",
                Exercise = "Упражение",
                FileLocation = "",
                IconLocation = "",
                Difficult = Difficulties.Beginner.ToString(),
                Points = 10,
                TopicId = 1
            });
    }
}
