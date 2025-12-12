using Microsoft.AspNetCore.Mvc;

namespace FrontToBack.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
