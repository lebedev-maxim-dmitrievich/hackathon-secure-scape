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
            Title = "Криптография",
            Description = "Криптография – это метод защиты информации путем использования закодированных алгоритмов, хэшей и подписей. Информация может находиться на этапе хранения (например, файл на жестком диске), передачи (например, электронная связь между двумя или несколькими сторонами) или использования (при применении для вычислений).",
            ImageLocation = Path.Combine("media", "images", "topics", "reverse-engineering.jpg")
        },
        new Topic
        {
            Id = 2,
            Title = "Реверс-инжиниринг",
            Description = "Реверсивный инжиниринг (реверс инжиниринг, обратное проектирование, reverse-engineering) – процесс создания точной копии объекта по уже существующему образцу, обладающей такими же физическими характеристиками. Реверс-инжиниринг полезен в случаях, когда производитель хочет импортозаместить компонент или...",
            ImageLocation = Path.Combine("media", "images", "topics", "cryptography.jpg")
        },
        new Topic
        {
            Id = 3,
            Title = "Стенография",
            Description = "Стеганография — это способ спрятать информацию внутри другой информации или физического объекта так, чтобы ее нельзя было обнаружить. С помощью стеганографии можно спрятать практически любой цифровой контент, включая тексты, изображения, аудио- и видеофайлы. А когда эта спрятанная информация поступает к адресату, ее извлекают.",
            ImageLocation = Path.Combine("media", "images", "topics", "steganography.jpg")
        });


        builder.Entity<Theory>().HasData(
            new Theory
            {
                Id = 1,
                Article = "Теория по реверс-инжирингу",
                Title = "Реверс-инжиниринг - это",
                TopicId = 1
            });

        builder.Entity<TaskEntity>().HasData(
            new TaskEntity
            {
                Id = 1,
                Title = "Размножение вирусов",
                Description = "Компьютер Боба заражен вирусом, который непрерывно размножается. Одну миллисекунду вновь рожденный вирус обживается, а затем каждую следующую миллисекунду производит новую копию самого себя. Все началось с одной единственнной копии. Боб обратился за помощью к Тренту, и тот нашел ошибку в программе вируса. Оказывается, что, как только количество копий станет кратно 232, все они будут мгновенно уничтожены,и компьютер будет спасен. Стоит ли Бобу надеяться на спасение? Если да, то как долго придется ждать? Напишите число сутков.",
                Answer = "38",
                FileLocation = "",
                IconLocation = Path.Combine("media", "images", "tasks", "task1.png"),
                Difficult = Difficulties.Beginner.ToString(),
                Points = 10,
                TopicId = 1
            },
            new TaskEntity
            {
                Id = 2,
                Title = "Поиск загаданного числа",
                Description = "Вам был предоставлен загадочный файл, который содержит загаданное число. Ваша задача - найти это число. Вы можете использовать любые доступные вам инструменты для анализа файла, но помните, что вы не можете изменять его. Ваша цель - определить загаданное число, используя только статистические данные, полученные из анализа файла.",
                Answer = "58",
                FileLocation = Path.Combine("media", "files", "tasks", "SearchFlag.exe"),
                IconLocation = Path.Combine("media", "images", "tasks", "task2.png"),
                Difficult = Difficulties.Beginner.ToString(),
                Points = 10,
                TopicId = 2
            });
    }
}
