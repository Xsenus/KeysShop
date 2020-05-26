using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KeysShop.Data.Models
{
    public class ShopBasket
    {
        private readonly AppDBContent appDBContent;

        public ShopBasket(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public string ShopBasketId { get; set; }
        public List<Basket> Baskets { get; set; }

        public static ShopBasket GetProduct(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = service.GetService<AppDBContent>();
            var shopBasketId = session.GetString("BasketId") ?? Guid.NewGuid().ToString();

            session.SetString("BasketId", shopBasketId);

            return new ShopBasket(context) { ShopBasketId = shopBasketId };
        }

        public void AddToShopBasket(Product product, double amount)
        {
            appDBContent.Baskets.Add(new Basket()
            {
                ShopBasketId = ShopBasketId,
                Product = product,
                Price = product.Price
            });

            appDBContent.SaveChanges();
        }

        public List<Basket> GetShopBasket()
        {
            return appDBContent.Baskets.Where(w => w.ShopBasketId.Equals(ShopBasketId)).Include(i => i.Product).ToList();
        }
    }
}
