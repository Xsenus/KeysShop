using KeysShop.Data.Interface;
using KeysShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace KeysShop.Controllers
{
    public class HomeController : Controller
    {
        private IProduct product;

        public HomeController(IProduct product)
        {
            this.product = product;
        }

        public ViewResult Index()
        {
            var homeProduct = new HomeViewModel()
            {
                FavoriteProducts = product.GetFavorites
            };

            return View(homeProduct);
        }
    }
}
