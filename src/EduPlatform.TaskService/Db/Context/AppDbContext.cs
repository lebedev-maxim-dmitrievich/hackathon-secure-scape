using EduPlatform.TaskService.Entities;
using Microsoft.EntityFrameworkCore;

namespace EduPlatform.TaskService.Db.Context;

public class AppDbContext : DbContext
{
    public DbSet<TaskEntity> Tasks => Set<TaskEntity>();
    public DbSet<Theory> Theories => Set<Theory>();
    public DbSet<Topic> Topics => Set<Topic>();


    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }
}
