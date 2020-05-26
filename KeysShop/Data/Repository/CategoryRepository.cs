using KeysShop.Data.Interface;
using KeysShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KeysShop.Data.Repository
{
    public class CategoryRepository : IProductsCategory
    {
        private readonly AppDBContent appDBContent;
        public CategoryRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Category> Categories => appDBContent.Categories;
    }
}
