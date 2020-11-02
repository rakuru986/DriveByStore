using System.Linq;
using Models.Data;

namespace Models.Context
{
    public static class StoreDbInitializer
    {
        public static void Initialize(StoreDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Products.Any() || context.ProductCategories.Any()) return;

            var categories = new[]
            {
                new ProductCategoriesData{Id = "1", Name = "Cars"},
                new ProductCategoriesData{Id = "2", Name = "Motorcycles"},
                new ProductCategoriesData{Id = "3", Name = "Scooters"},
                new ProductCategoriesData{Id = "4", Name = "Skateboards"},
                new ProductCategoriesData{Id = "5", Name = "Bicycles"},
                new ProductCategoriesData{Id = "6", Name = "Tools"},
            };

            context.ProductCategories.AddRange(categories);
            context.SaveChanges();

            var products = new []
            {
                new ProductData{Id = "1", Description = "Uus Audi A8", Name = "Audi A8", Price = 121000, Image = "assets/images/artur.jpeg", ProductCategory = categories[0], Stock = 5},
                new ProductData{Id = "2", Description = "Uus Audi A7", Name = "Audi A7", Price = 105000, Image = "assets/images/artur.jpeg", ProductCategory = categories[0], Stock = 3},
                new ProductData{Id = "3", Description = "Tutikas Kawasaki Z400 mootorratas", Name = "Kawasaki Z400", Price = 15000, Image = "assets/images/artur.jpeg", ProductCategory = categories[1], Stock = 6},
                new ProductData{Id = "4", Description = "Tutikas Kawasaki KX450 mootorratas", Name = "Kawasaki KX450", Price = 17000, Image = "assets/images/artur.jpeg", ProductCategory = categories[1], Stock = 12},
                new ProductData{Id = "5", Description = "Tänavalt varastatud bolti tõuks", Name = "BOLT TÕUX", Price = 690, Image = "assets/images/artur.jpeg", ProductCategory = categories[2], Stock = 15},
                new ProductData{Id = "6", Description = "Razor 28T trikitõukeratas", Name = "Razor 28T", Price = 370, Image = "assets/images/artur.jpeg", ProductCategory = categories[2], Stock = 4},
                new ProductData{Id = "7", Description = "Uus Vans TH3 rula", Name = "Vans TH3", Price = 250, Image = "assets/images/artur.jpeg", ProductCategory = categories[3], Stock = 10},
                new ProductData{Id = "8", Description = "Uus Vans TH5 rula", Name = "Vans TH5", Price = 370, Image = "assets/images/artur.jpeg", ProductCategory = categories[3], Stock = 3},
                new ProductData{Id = "9", Description = "Uus jalgratas Merida R3", Name = "Merida R3", Price = 800, Image = "assets/images/artur.jpeg", ProductCategory = categories[4], Stock = 14},
                new ProductData{Id = "10", Description = "Uus jalgratas Merida T7", Name = "Merida T7", Price = 700, Image = "assets/images/artur.jpeg", ProductCategory = categories[4], Stock = 11},
                new ProductData{Id = "11", Description = "Uhiuus kruvikeeraja Stanley F10", Name = "Stanley F10", Price = 20, Image = "assets/images/artur.jpeg", ProductCategory = categories[5], Stock = 71},
                new ProductData{Id = "12", Description = "Uhiuus kruvikeeraja Stanley F18", Name = "Stanley F18", Price = 30, Image = "assets/images/artur.jpeg", ProductCategory = categories[5], Stock = 54}
            };

            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
}
