using KeysShop.Data.Interface;
using KeysShop.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KeysShop.Data.Repository
{
    public class ProductRepository : IProduct
    {
        private readonly AppDBContent appDBContent;

        public ProductRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Product> Products => 
            appDBContent.Products.Include(i => i.Category);
        public IEnumerable<Product> GetFavorites => appDBContent.Products.Where(w => w.IsFavorite).Include(i => i.Category);
        public Product GetObject(int objId) => appDBContent.Products.FirstOrDefault(f => f.ProductId == objId);
    }
}
