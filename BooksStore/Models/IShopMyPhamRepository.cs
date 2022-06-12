using System.Linq;
namespace ShopMyPham.Models
{
    public interface IShopMyPhamRepository
    {
        IQueryable<Book> Books { get; }
        void SaveBook(Book b);
        void CreateBook(Book b);
        void DeleteBook(Book b);
    }
}