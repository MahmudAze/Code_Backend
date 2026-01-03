using MainBackend.Data;
using MainBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MainBackend.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Product> products = await _context.Products
                .Include(m => m.ProductImages)
                .Include(m => m.Category)
                .Where(m => !m.IsDeleted)
                .Take(4)
                .ToListAsync();

            return View(products);
        }

        // Move this here from HomeController
        public async Task<IActionResult> LoadMore(int skip)
        {
            IEnumerable<Product> products = await _context.Products
                .Include(m => m.ProductImages)
                .Include(m => m.Category)
                .Where(m => !m.IsDeleted)
                .Skip(skip)
                .Take(4)
                .ToListAsync();

            return PartialView("_ProductPartial", products);
        }
    }
}
