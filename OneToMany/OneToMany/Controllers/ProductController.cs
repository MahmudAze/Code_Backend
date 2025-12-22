using Microsoft.AspNetCore.Mvc;

namespace OneToMany.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
