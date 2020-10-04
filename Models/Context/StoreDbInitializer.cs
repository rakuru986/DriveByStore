using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models.Data;

namespace Models.Context
{
    public static class StoreDbInitializer
    {
        public static void Initialize(StoreDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Products.Any()) return;

            var products = new ProductData[]
            {
                new ProductData{Id = "1", Description = "Kiire auto", Name = "Ferrari F12", Price = 320000, ProductCategoryId = "1", Stock = 5},
                new ProductData{Id = "2", Description = "Aeglane auto", Name = "Mazda 6", Price = 2000, ProductCategoryId = "1", Stock = 3},
                new ProductData{Id = "3", Description = "Luksuslik auto", Name = "Rolls-Royce Phantom", Price = 500000, ProductCategoryId = "1", Stock = 2},
                new ProductData{Id = "4", Description = "Maitsev kook", Name = "Napoleoni kook", Price = 12, ProductCategoryId = "2", Stock = 10},
                new ProductData{Id = "5", Description = "Mmmm...", Name = "Šokolaadi muffin", Price = 2, ProductCategoryId = "2", Stock = 15}
            };

            context.Products.AddRange(products);
            context.SaveChanges();

            var categories = new ProductCategoriesData[]
            {
                new ProductCategoriesData{Id = "1", Name = "Auto"},
                new ProductCategoriesData{Id = "2", Name = "Magustoit"}
            };

            context.ProductCategories.AddRange(categories);
            context.SaveChanges();
        }
    }
}
