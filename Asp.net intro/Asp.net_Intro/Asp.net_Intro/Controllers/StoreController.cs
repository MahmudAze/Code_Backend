using Microsoft.AspNetCore.Mvc;

namespace Asp.net_Intro.Controllers
{
    public class StoreController : Controller
    {
        public IActionResult Store()
        {
            return View();
        }
    }
}