using KeysShop.Data.Models;
using System.Collections.Generic;

namespace KeysShop.Data.Interface
{
    public interface IProduct
    {
        IEnumerable<Product> Products { get; }
        IEnumerable<Product> GetFavorites { get; }
        Product GetObject(int objId);
    }
}
