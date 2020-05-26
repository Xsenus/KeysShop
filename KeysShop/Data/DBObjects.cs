using KeysShop.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;

namespace KeysShop.Data
{
    public class DBObjects
    {
        public static void Initial(IApplicationBuilder applicationBuilder)
        {
            using (var scope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var appDBContent = scope.ServiceProvider.GetRequiredService<AppDBContent>();
                if (!appDBContent.Categories.Any())
                {
                    appDBContent.Categories.AddRange(DBObjects.CreateCategories().Select(s => s.Value));
                    appDBContent.SaveChanges();
                }

                if (!appDBContent.Products.Any())
                {
                    appDBContent.AddRange(
                        new Product() { IsFavorite = true, Name = "Windows 10 Pro", Description = "Операционная система Windows 10 Pro", Image = "/img/windows_10_pro.jpg", Price = 400, Category = appDBContent.Categories.FirstOrDefault(f => f.CategoryName.Equals("Операционные системы")) },
                        new Product() { IsFavorite = false, Name = "Windows 10 Home", Description = "Операционная система Windows 10 Home", Price = 450, Category = appDBContent.Categories.FirstOrDefault(f => f.CategoryName.Equals("Операционные системы")) },
                        new Product() { IsFavorite = true, Name = "Microsoft Office 2020 Pro", Description = "Microsoft Office 2020 Pro", Price = 1000, Category = appDBContent.Categories.FirstOrDefault(f => f.CategoryName.Equals("Программное обеспечение")) }
                    );

                    appDBContent.SaveChanges();
                }
            }
        }
        public static void Initial(AppDBContent appDBContent)
        {            
            if (!appDBContent.Categories.Any())
            {
                appDBContent.Categories.AddRange(DBObjects.CreateCategories().Select(s => s.Value));
                appDBContent.SaveChanges();
            }

            if (!appDBContent.Products.Any())
            {
                appDBContent.AddRange(
                    new Product() { Name = "Windows 10 Pro", Description = "Операционная система Windows 10 Pro", Image = "/img/windows_10_pro.jpg", Price = 400, Category = appDBContent.Categories.FirstOrDefault(f => f.CategoryName.Equals("Операционные системы")) },
                    new Product() { Name = "Windows 10 Home", Description = "Операционная система Windows 10 Home", Price = 450, Category = appDBContent.Categories.FirstOrDefault(f => f.CategoryName.Equals("Операционные системы")) },
                    new Product() { Name = "Microsoft Office 2020 Pro", Description = "Microsoft Office 2020 Pro", Price = 1000, Category = appDBContent.Categories.FirstOrDefault(f => f.CategoryName.Equals("Программное обеспечение")) }
                );

                appDBContent.SaveChanges();
            }
        }

        public static Dictionary<string, Category> CreateCategories()
        {
            var listCategory = new List<Category>();

            listCategory.Add(new Category() { CategoryName = "Операционные системы" });
            listCategory.Add(new Category() { CategoryName = "Программное обеспечение" });

            var category = new Dictionary<string, Category>();

            foreach (var item in listCategory)
            {
                category.Add(item.CategoryName, item);
            }

            return category;
        }
    }
}
