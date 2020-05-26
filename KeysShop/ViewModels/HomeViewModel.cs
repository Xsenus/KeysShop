using KeysShop.Data.Models;
using System.Collections.Generic;

namespace KeysShop.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Product> FavoriteProducts { get; set; }
    }
}
