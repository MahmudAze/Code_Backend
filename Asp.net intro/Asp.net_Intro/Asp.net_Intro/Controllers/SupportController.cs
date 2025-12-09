using Microsoft.AspNetCore.Mvc;

namespace Asp.net_Intro.Controllers
{
    public class SupportController : Controller
    {
        public IActionResult Support()
        {
            return View();
        }
    }
}