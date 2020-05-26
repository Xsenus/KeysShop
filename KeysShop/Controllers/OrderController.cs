using KeysShop.Data.Interface;
using KeysShop.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace KeysShop.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrder orders;
        private readonly ShopBasket shopBasket;

        public OrderController(IOrder orders, ShopBasket shopBasket)
        {
            this.orders = orders;
            this.shopBasket = shopBasket;
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            shopBasket.Baskets = shopBasket.GetShopBasket();

            if (shopBasket.Baskets.Count == 0)
            {
                ModelState.AddModelError("", "У вас должны быть товары");
            }

            if (ModelState.IsValid)
            {
                orders.CreateOrder(order);
                return RedirectToAction("Complete");
            }

            return View(order);
        }

        public IActionResult Complete()
        {
            ViewBag.Message = "Заказ успешно обработан";
            return View();
        }
    }
}
