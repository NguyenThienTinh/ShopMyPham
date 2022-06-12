using System.Linq;
namespace ShopMyPham.Models
{
    public class EFShopMyPhamRepository : IShopMyPhamRepository
    {
        private ShopMyPhamDbContext context;
        public EFShopMyPhamRepository(ShopMyPhamDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Book> Books => context.Books;
        public void CreateBook(Book b)
        {
            context.Add(b);
            context.SaveChanges();
        }
        public void DeleteBook(Book b)
        {
            context.Remove(b); context.SaveChanges();
        }
        public void SaveBook(Book b)
        {
            context.SaveChanges();
        }
    }
}