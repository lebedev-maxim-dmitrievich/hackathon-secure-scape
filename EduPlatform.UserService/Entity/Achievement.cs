namespace EduPlatform.UserService.Entity
{
    public class Achievement
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string RelativeIconLocation { get; set; } = string.Empty;
        public string Rerequirement { get; set; } = string.Empty;
        public int Rarity { get; set; }

        public Progress Progress { get; set; } = null!;
    }
}
