using Microsoft.AspNetCore.Mvc;
using ShopMyPham.Models;
using System.Linq;
using ShopMyPham.Models.ViewModels;

namespace ShopMyPham.Controllers
{
    public class HomeController : Controller
    {
        private IShopMyPhamRepository repository;
        public int PageSize = 3;
        public HomeController(IShopMyPhamRepository repo)
        {
            repository = repo;
        }
        public IActionResult Index(string genre, int bookPage = 1)
            => View(new BooksListViewModel
            {

                Books = repository.Books
                    .Where(p => genre == null || p.Genre == genre)
                    .OrderBy(b => b.BookID)
                    .Skip((bookPage - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = bookPage,
                    ItemsPerPage = PageSize,
                    TotalItems = genre == null ?
                    repository.Books.Count() : repository.Books.Where(e => e.Genre == genre).Count()

                },
                CurrentGenre = genre
            });
    }
}