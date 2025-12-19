using Microsoft.EntityFrameworkCore;
using OneToMany.Models;

namespace OneToMany.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Slider> sliders { get; set; }
    }
}
