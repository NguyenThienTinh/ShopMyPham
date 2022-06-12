using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopMyPham.Models;
namespace ShopMyPham.ViewComponents
{
    public class GenreNavigation : ViewComponent
    {
        private IShopMyPhamRepository repository;
        public GenreNavigation(IShopMyPhamRepository repo)
        {
            repository = repo;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedGenre = RouteData?.Values["genre"];
            return View(repository.Books
            .Select(x => x.Genre)
            .Distinct()
            .OrderBy(x => x));
        }
    }
}