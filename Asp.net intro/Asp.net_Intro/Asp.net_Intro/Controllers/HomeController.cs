using Microsoft.AspNetCore.Mvc;

namespace Asp.net_Intro.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
