using KeysShop.Data.Interface;
using KeysShop.Data.Models;
using KeysShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeysShop.Controllers
{
    public class ShopBasketController : Controller
    {
        private IProduct productRepository;
        private readonly ShopBasket shopBasket;

        public ShopBasketController(IProduct productRepository, ShopBasket shopBasket)
        {
            this.productRepository = productRepository;
            this.shopBasket = shopBasket;
        }

        public ViewResult Index()
        {
            var items = shopBasket.GetShopBasket();
            shopBasket.Baskets = items;

            var obj = new ShopBasketViewModel()
            {
                ShopBasket = shopBasket
            };

            return View(obj);
        }

        public RedirectToActionResult AddToCart(int id)
        {
            var item = productRepository.Products.FirstOrDefault(f => f.ProductId == id);

            if (item != null)
            {
                shopBasket.AddToShopBasket(item, item.Price);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
