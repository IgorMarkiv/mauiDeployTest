using Microsoft.AspNetCore.Mvc;

namespace MauiDelployTestWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
