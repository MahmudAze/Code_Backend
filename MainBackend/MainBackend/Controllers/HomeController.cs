using System.Diagnostics;
using MainBackend.Data;
using MainBackend.Models;
using MainBackend.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MainBackend.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Slider> sliders = await _context.Sliders.Where(m => !m.IsDeleted).ToListAsync();

            SliderDetail sliderDetails = await _context.SliderDetails.FirstOrDefaultAsync(m => !m.IsDeleted);

            HomeVM homeVM = new()
            {
                Sliders = sliders,
                SliderDetails = sliderDetails
            };

            return View(homeVM);
        }
    }
}
