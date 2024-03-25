using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EduPlatform.Entry.Controllers;

public class HomeController : ControllerBase
{
    [HttpGet("/")]
    public async Task<IActionResult> Index()
    {
         return Redirect("index.html");
    }
}
