using System;

namespace EduPlatform.UserService.Enum.Logic
{
    public static class LevelLogic
    {
        public static Levels SetLevel(long score) 
        {
            switch (score)
            {
                case >= 101 and <= 250:
                    return Levels.CyberIntern;
                case >= 251 and <= 400:
                    return Levels.CyberAdept;
                case >= 401 and <= 600:
                    return Levels.CyberGuardian;
                case >= 601 and <= 1000:
                    return Levels.CyberIntern;
                default:
                    return Levels.CyberNoob;
            }
        }
    }
}
