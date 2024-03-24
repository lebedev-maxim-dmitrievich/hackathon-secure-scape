using System;

namespace EduPlatform.TaskService.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string name, string key)
            : base($"Cущность '{name}' по ключу ({key}) не найдена.") { }
}
