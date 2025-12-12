using Microsoft.AspNetCore.Mvc;

namespace FrontToBack.Controllers
{
    public class WorkSingleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
