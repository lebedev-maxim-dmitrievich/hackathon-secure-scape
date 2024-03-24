using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;
using System.IO;

namespace EduPlatform.Entry
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //builder.Services.AddControllers();

            var app = builder.Build();

            app.UseStaticFiles(new StaticFileOptions
            { 
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(builder.Environment.ContentRootPath, "..", "..", "resources"))
            });

            //app.MapControllers();

            app.UseStaticFiles();

            app.MapGet("/", () => "Hello world from Entry");

            app.Run();
        }
    }
}
