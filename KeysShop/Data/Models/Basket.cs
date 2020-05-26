namespace KeysShop.Data.Models
{
    public class Basket
    {
        public int BasketID { get; set; }
        public string ShopBasketId { get; set; }
        public Product Product { get; set; }
        public double Price { get; set; }           
    }
}
