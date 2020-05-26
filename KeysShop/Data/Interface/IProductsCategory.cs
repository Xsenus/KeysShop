using KeysShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KeysShop.Data.Interface
{
    public interface IProductsCategory
    {
        IEnumerable<Category> Categories { get; }
    }
}
