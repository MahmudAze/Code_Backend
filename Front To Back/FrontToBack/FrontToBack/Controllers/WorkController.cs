using Microsoft.AspNetCore.Mvc;

namespace FrontToBack.Controllers
{
    public class WorkController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
