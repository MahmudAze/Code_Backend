using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace MainBackend.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
