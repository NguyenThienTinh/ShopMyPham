using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
namespace ShopMyPham.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ShopMyPhamDbContext context =
           app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService < ShopMyPhamDbContext > ();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if (!context.Books.Any())
            {
                context.Books.AddRange(
                 new Book
                 {
                     Title = "Trang Điểm Son",
                     Description = "Màu khoáng làm son sáp (new 2019)_ Nguyên liệu làm son, mỹ phẩm handmade",
                     Genre = "Còn hàng",
                     Price = 22.0m
                 },
                new Book
                {

                    Title = "Bông Trang Điểm",
                    Description = "Bộ 3 hộp Bông trang điểm (bông tẩy trang) Silcot 82 miếng/hộp",
                    Genre = "Hết hàng",
                    Price = 17.46m
                },
                new Book
                {

                    Title = "Chăm Sóc Móng",
                    Description = "Base top hoa hồng , sơn liên kết móng 15ml",
                    Genre = "Mới ra hàng",
                    Price = 30.1m
                },
                new Book
                {

                    Title = "Bộ sản phẩm làm đẹp",
                    Description = "Bộ trang điểm đầy đủ 10 món cơ bản từ a-z set trang điểm cá nhân Hatola",
                    Genre = "Sắp ra hàng",
                    Price = 18.9m
                },
                new Book
                {

                    Title = "Bộ Sản phẩm làm đẹp",
                    Description = "Bộ đôi Senka sữa tắm hương hoa dịu ngọt 500ml và sữa rửa mặt đất sét trắng 120g",
                    Genre = "Còn hàng",
                    Price = 31.6m               
                }
                );
                context.SaveChanges();
            }
        }
    }
}
