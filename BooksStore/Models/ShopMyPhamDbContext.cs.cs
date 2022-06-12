using Microsoft.EntityFrameworkCore;
namespace ShopMyPham.Models
{
    public class ShopMyPhamDbContext : DbContext
    {
        public ShopMyPhamDbContext(DbContextOptions<ShopMyPhamDbContext> options)
        : base(options) { }
        public DbSet<Book> Books { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}