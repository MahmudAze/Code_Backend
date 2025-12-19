using Microsoft.AspNetCore.Mvc;
using OneToMany.Data;
using OneToMany.Models;
using System.Diagnostics;

namespace OneToMany.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Slider> Sliders = _context.Sliders.ToList();
            return View(Sliders);
        }
    }
}
