using KeysShop.Data.Interface;
using KeysShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KeysShop.Data.Mocks
{
    public class MockCategory : IProductsCategory
    {
        public IEnumerable<Category> Categories
        {
            get
            {
                return new List<Category>()
                {
                    new Category()
                    {
                        CategoryName = "Операционные системы"
                    },

                    new Category()
                    {
                        CategoryName = "Программное обеспечение"
                    }
                };
            }
        }
    }
}
