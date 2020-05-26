using KeysShop.Data.Interface;
using KeysShop.Data.Models;
using KeysShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace KeysShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProduct product;
        private readonly IProductsCategory productsCategory;

        public ProductController(IProduct product, IProductsCategory productsCategory)
        {
            this.product = product;
            this.productsCategory = productsCategory;
        }

        [Route("Product/List")]
        [Route("Product/List/{category}")]
        public ViewResult List(string category)
        {
            var productListViewModel = new ProductListViewModel();

            IEnumerable<Product> products = product.Products.OrderBy(o => o.ProductId);

            if (!string.IsNullOrWhiteSpace(category))
            {
                if (string.Equals("w1", category, System.StringComparison.OrdinalIgnoreCase))
                {
                    products = product.Products
                    .Where(w => w.Category != null && w.Category.CategoryName.Equals("Операционные системы"))
                    .OrderBy(o => o.ProductId);                    
                }
                else if (string.Equals("w2", category, System.StringComparison.OrdinalIgnoreCase))
                {
                    products = product.Products
                    .Where(w => w.Category != null && w.Category.CategoryName.Equals("Программное обеспечение"))
                    .OrderBy(o => o.ProductId);
                }

                productListViewModel.CurrentCategory = products.Select(s => s.Category).FirstOrDefault().CategoryName;
            }

            ViewBag.Ttile = "Продукты";            
            //productListViewModel.Products = this.product.Products;
            productListViewModel.Products = products;
            //productListViewModel.CurrentCategory = product.Products.Select(f => f.Category).FirstOrDefault().CategoryName;
            //productListViewModel.CurrentCategory = products.Select(f => f.Category).FirstOrDefault().CategoryName;

            //ViewBag.Category = "Some new";
            //var product = this.product.Products;
            return View(productListViewModel);
        }
    }
}
