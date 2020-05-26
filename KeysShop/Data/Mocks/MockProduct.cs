using KeysShop.Data.Interface;
using KeysShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KeysShop.Data.Mocks
{
    public class MockProduct : IProduct
    {
        private readonly IProductsCategory productsCategory = new MockCategory();

        public IEnumerable<Product> Products
        {
            get
            {
                return new List<Product>()
                {
                    new Product() { Name = "Windows 10 Pro", Description = "Операционная система Windows 10 Pro", Image = "/img/windows_10_pro.jpg", Price = 400, Category = productsCategory.Categories.FirstOrDefault(f => f.CategoryName.Equals("Операционные системы")) },
                    new Product() { Name = "Windows 10 Home", Description = "Операционная система Windows 10 Home", Price = 450, Category = productsCategory.Categories.FirstOrDefault(f => f.CategoryName.Equals("Операционные системы")) },
                    new Product() { Name = "Microsoft Office 2020 Pro", Description = "Microsoft Office 2020 Pro", Price = 1000, Category = productsCategory.Categories.FirstOrDefault(f => f.CategoryName.Equals("Программное обеспечение")) }
                };
            }
        }

        public IEnumerable<Product> GetFavorites { get; set; }

        public Product GetObject(int objId)
        {
            throw new NotImplementedException();
        }
    }
}
