using System;
using System.Collections.Generic;
using System.Linq;

namespace KeysShop.Data.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Desc { get; set; }
        public List<Product> Products { get; set; }
    }
}
