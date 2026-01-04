using MainBackend.Areas.Admin.ViewModels.CategoryVMs;
using MainBackend.Data;
using MainBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MainBackend.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Category> categories = await _context.Categories.OrderByDescending(c => c.Id).Where(c => !c.IsDeleted).ToListAsync();

            IEnumerable<GetAllCategoryVM> getAllCategoryVMs = categories.Select(c => new GetAllCategoryVM()
            {
                Name = c.Name
            });


            return View(getAllCategoryVMs);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CategoryCreateVM());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryCreateVM categoryVM)
        {
            if (!ModelState.IsValid) return View(categoryVM);

            // Daha temiz ve suretli yoxlanis
            bool isExist = await _context.Categories
                .AnyAsync(c => c.Name.Trim().ToLower() == categoryVM.Name.ToLower().Trim());

            if (isExist)
            {
                ModelState.AddModelError("Name", "Bu adda kateqoriya artıq mövcuddur!");
                return View(categoryVM);
            }

            // VM-dən Entity-yə keçid (Mapping)
            Category category = new()
            {
                Name = categoryVM.Name.Trim()
            };

            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
