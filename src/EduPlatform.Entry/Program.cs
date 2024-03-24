namespace EduPlatform.Entry
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            var app = builder.Build();

            app.MapControllers();

            app.MapGet("/", () => "Hello world from Entry");

            app.Run();
        }
    }
}
