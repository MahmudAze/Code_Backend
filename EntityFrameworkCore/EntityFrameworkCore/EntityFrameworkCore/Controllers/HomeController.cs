using System.Diagnostics;
using EntityFrameworkCore.Data;
using EntityFrameworkCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkCore.Controllers
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
            List<Slider> sliders = _context.sliders.ToList();
            return View(sliders);

        }
    }
}
