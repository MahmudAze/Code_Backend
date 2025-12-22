using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OneToMany.Areas.Admin.ViewModels;
using OneToMany.Data;
using OneToMany.Models;

namespace OneToMany.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderDetailController : Controller
    {
        private readonly AppDbContext _context;

        public SliderDetailController(AppDbContext context)
        {
            _context = context;
        }



        public async Task<IActionResult> Index()
        {
            IEnumerable<Slider> sliders = await _context.Sliders.Where(m => !m.IsDeleted).ToListAsync();
            SliderDetail sliderDetail = await _context.SlidersDetails.FirstOrDefaultAsync(m => !m.IsDeleted);

            SliderVM sliderVM = new()
            {
                Sliders = sliders,
                SliderDetail = sliderDetail
            };

            return View(sliderVM);
        }
    }
}
