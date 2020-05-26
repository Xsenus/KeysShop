using KeysShop.Data.Interface;
using KeysShop.Data.Models;
using System;

namespace KeysShop.Data.Repository
{
    public class OrderRepository : IOrder
    {
        private readonly AppDBContent appDBContent;
        private readonly ShopBasket shopBasket;

        public OrderRepository(AppDBContent appDBContent, ShopBasket shopBasket)
        {
            this.appDBContent = appDBContent;
            this.shopBasket = shopBasket;
        }

        public void CreateOrder(Order order)
        {
            order.Date = DateTime.Now;
            appDBContent.Orders.Add(order);

            var items = shopBasket.Baskets;

            foreach (var basket in items)
            {
                var orderDetail = new OrderDetail()
                {
                    Product = basket.Product,
                    Order = order,
                    Price = basket.Product.Price
                };

                appDBContent.OrderDetails.Add(orderDetail);
            }

            appDBContent.SaveChanges();
        }
    }
}
