using Microsoft.AspNetCore.Mvc;

namespace Asp.net_Intro.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult About()
        {
            return View();
        }
    }
}
