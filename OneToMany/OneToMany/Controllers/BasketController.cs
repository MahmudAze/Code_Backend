using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OneToMany.Data;
using OneToMany.Models;
using OneToMany.ViewModels.BasketVMs;
using System.Threading.Tasks;

namespace OneToMany.Controllers
{
    public class BasketController : Controller
    {
        private readonly AppDbContext _context;

        public BasketController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // 1. Kukini oxuyuruq
            string basketJson = HttpContext.Request.Cookies["basket"];
            if (string.IsNullOrEmpty(basketJson))
                return View(new List<BasketDetailVM>()); // Səbət boşdursa boş siyahı göndər

            List<BasketVM> basket = JsonConvert.DeserializeObject<List<BasketVM>>(basketJson);

            // 2. Kukidəki bütün ID-ləri bir siyahıya yığırıq
            List<int> ids = basket.Select(i => i.Id).ToList();

            // 3. BAZAYA TƏK BİR SORĞU GÖNDƏRİRİK (Performans buradadır!)
            var products = await _context.Products
                .Include(m => m.Category) // Kateqoriya məlumatını qoş
                .Include(m => m.ProductImages) // Şəkilləri qoş
                .Where(m => ids.Contains(m.Id) && !m.IsDeleted) // Siyahıdakı ID-ləri tap
                .ToListAsync();

            // 4. Bazadan gələn real məlumatlarla kukidəki sayı (Count) birləşdiririk
            List<BasketDetailVM> basketDetailVMs = new();

            foreach (var product in products)
            {
                // Kukidə bu məhsuldan neçə dənə olduğunu tapırıq
                var basketItem = basket.FirstOrDefault(b => b.Id == product.Id);

                basketDetailVMs.Add(new BasketDetailVM
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Count = basketItem.Count, // Kukidən gəlir
                    TotalPrice = product.Price * basketItem.Count,
                    Category = product.Category.Name,
                    Image = product.ProductImages.FirstOrDefault(m => m.IsMain)?.Image
                });
            }

            return View(basketDetailVMs); // Artıq detallı siyahını göndəririk!
        }


        [HttpPost]
        public async Task<IActionResult> Add(int? id)
        {
            if (id is null) return BadRequest();

            bool isExist = await _context.Products.AnyAsync(m => m.Id == id);

            if (!isExist) return NotFound();

            List<BasketVM> basketVMs;

            if (HttpContext.Request.Cookies["basket"] != null)
            {
                basketVMs = JsonConvert.DeserializeObject<List<BasketVM>>(HttpContext.Request.Cookies["basket"]);
            }
            else
            {
                basketVMs= new List<BasketVM>();
            }

            var existProduct = basketVMs.FirstOrDefault(c => c.Id == id);

            if (existProduct != null)
            {
                existProduct.Count++;
            }
            else
            {
                basketVMs.Add(new BasketVM()
                {
                    Id = (int)id,
                    Count = 1
                });
            }


            HttpContext.Response.Cookies.Append("basket", JsonConvert.SerializeObject(basketVMs));

            return RedirectToAction("Index", "Home");
        }
    }
}
