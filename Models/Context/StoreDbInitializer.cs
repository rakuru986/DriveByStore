using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Models.Data;

namespace Models.Context
{
    public static class StoreDbInitializer
    {
        public static void Initialize(StoreDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Products.Any() || context.ProductCategories.Any()) return;

            var categories = new ProductCategoriesData[]
            {
                new ProductCategoriesData{Id = "aaa", Name = "Auto"},
                new ProductCategoriesData{Id = "bbb", Name = "Magustoit"}
            };

            context.ProductCategories.AddRange(categories);
            context.SaveChanges();

            var products = new ProductData[]
            {
                new ProductData{Id = "1", Description = "Kiire auto", Name = "Ferrari F12", Price = 320000, ProductCategory = context.ProductCategories.First(x => x.Id == "aaa"), Stock = 5},
                new ProductData{Id = "2", Description = "Aeglane auto", Name = "Mazda 6", Price = 2000, ProductCategory = context.ProductCategories.First(x => x.Id == "aaa"), Stock = 3},
                new ProductData{Id = "3", Description = "Luksuslik auto", Name = "Rolls-Royce Phantom", Price = 500000, ProductCategory = context.ProductCategories.First(x => x.Id == "aaa"), Stock = 2},
                new ProductData{Id = "4", Description = "Maitsev kook", Name = "Napoleoni kook", Price = 12, ProductCategory = context.ProductCategories.First(x => x.Id == "aaa"), Stock = 12},
                new ProductData{Id = "5", Description = "Mmmm...", Name = "Šokolaadi muffin", Price = 2, ProductCategory = context.ProductCategories.First(x => x.Id == "aaa"), Stock = 15}
            };

            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
}
