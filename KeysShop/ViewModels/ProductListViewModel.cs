using KeysShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KeysShop.ViewModels
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; }

        public string CurrentCategory { get; set; }
    }
}
