using Microsoft.AspNetCore.Mvc;

namespace Asp.net_Intro.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Order()
        {
            return View();
        }
    }
}