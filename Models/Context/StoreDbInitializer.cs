using System.Linq;
using Models.Data.Products;

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
                new ProductData{Id = "1", Description = "Uus Audi A8", Name = "Audi A8", Price = 121000, Image = "assets/images/cars/audiA8.jpg", ProductCategory = categories[0], Stock = 5},
                new ProductData{Id = "2", Description = "Uus Audi A7", Name = "Audi A7", Price = 105000, Image = "assets/images/cars/audiA7.jpg", ProductCategory = categories[0], Stock = 3},

                new ProductData{Id = "3", Description = "Tutikas Kawasaki Z400 mootorratas", Name = "Kawasaki Z400", Price = 15000, Image = "assets/images/motorcycles/kawasaki2.jpg", ProductCategory = categories[1], Stock = 8},
                new ProductData{Id = "4", Description = "Tutikas Kawasaki KX450 mootorratas", Name = "Kawasaki KX450", Price = 10000, Image = "assets/images/motorcycles/kawasaki3.jpg", ProductCategory = categories[1], Stock = 12},

                new ProductData{Id = "5", Description = "Tänavalt varastatud bolti tõuks", Name = "BOLT TÕUX", Price = 690, Image = "assets/images/scooters/scooter3.jpg", ProductCategory = categories[2], Stock = 15},
                new ProductData{Id = "6", Description = "Razor 28T trikitõukeratas", Name = "Razor 28T", Price = 370, Image = "assets/images/scooters/scooter4.jpg", ProductCategory = categories[2], Stock = 4},

                new ProductData{Id = "7", Description = "Uus Vans x Real Chima rula", Name = "Vans x Real Chima", Price = 250, Image = "assets/images/skateboards/skateboard1.jpg", ProductCategory = categories[3], Stock = 5},
                new ProductData{Id = "8", Description = "Uus Vans x Takashi Murakami rula", Name = "Vans x Takashi Murakami", Price = 470, Image = "assets/images/skateboards/skateboard2.jpg", ProductCategory = categories[3], Stock = 8},

                new ProductData{Id = "9", Description = "Uus jalgratas Merida Reacto 4000L", Name = "Merida Reacto 4000L", Price = 1900, Image = "assets/images/bicycles/bicycle1.jpg", ProductCategory = categories[4], Stock = 14},
                new ProductData{Id = "10", Description = "Uus jalgratas Merida Matts 6", Name = "Merida Matts 6", Price = 700, Image = "assets/images/bicycles/bicycle2.jpg", ProductCategory = categories[4], Stock = 11},

                new ProductData{Id = "11", Description = "Uhiuus kruvikeeraja TacTix F10", Name = "TacTix F10", Price = 20, Image = "assets/images/tools/tool1.jpg", ProductCategory = categories[5], Stock = 71},
                new ProductData{Id = "12", Description = "Uhiuus kruvikeeraja Rolson F18", Name = "Rolson F18", Price = 30, Image = "assets/images/tools/tool2.jpg", ProductCategory = categories[5], Stock = 54},

                new ProductData{Id = "13", Description = "Uus Audi A3", Name = "Audi A3", Price = 40000, Image = "assets/images/cars/audiA3.jpg", ProductCategory = categories[0], Stock = 5},
                new ProductData{Id = "14", Description = "Uus Audi A4", Name = "Audi A4", Price = 50000, Image = "assets/images/cars/audiA4.jpg", ProductCategory = categories[0], Stock = 7},
                new ProductData{Id = "15", Description = "Uus Audi A5", Name = "Audi A5", Price = 70000, Image = "assets/images/cars/audiA5.jpg", ProductCategory = categories[0], Stock = 4},
                new ProductData{Id = "16", Description = "Uus Audi A2", Name = "Audi A2", Price = 20000, Image = "assets/images/cars/audiA2.jpg", ProductCategory = categories[0], Stock = 9},
                new ProductData{Id = "17", Description = "Uus Audi A5", Name = "Audi A5", Price = 90000, Image = "assets/images/cars/audiA6.jpg", ProductCategory = categories[0], Stock = 4},

                new ProductData{Id = "18", Description = "Tutikas Kawasaki Ninja 650L mootorratas", Name = "Kawasaki Ninja 650L", Price = 30000, Image = "assets/images/motorcycles/kawasaki1.jpg", ProductCategory = categories[1], Stock = 5},
                new ProductData{Id = "19", Description = "Tutikas Kawasaki Vulcan mootorratas", Name = "Kawasaki Vulcan", Price = 28000, Image = "assets/images/motorcycles/kawasaki4.jpg", ProductCategory = categories[1], Stock = 4},
                new ProductData{Id = "20", Description = "Tutikas Kawasaki Z1000 mootorratas", Name = "Kawasaki Z1000", Price = 29000, Image = "assets/images/motorcycles/kawasaki5.jpg", ProductCategory = categories[1], Stock = 3},
                new ProductData{Id = "21", Description = "Tutikas Kawasaki Z750 mootorratas", Name = "Kawasaki Z750", Price = 23000, Image = "assets/images/motorcycles/kawasaki6.jpg", ProductCategory = categories[1], Stock = 15},

                new ProductData{Id = "22", Description = "Uus jalgratas Merida Dakar 524", Name = "Merida Dakar 624", Price = 300, Image = "assets/images/bicycles/bicycle3.jpg", ProductCategory = categories[4], Stock = 17},
                new ProductData{Id = "23", Description = "Uus jalgratas Merida Juliet 6.5", Name = "Merida Juliet 6.5", Price = 400, Image = "assets/images/bicycles/bicycle4.jpg", ProductCategory = categories[4], Stock = 11},
                new ProductData{Id = "24", Description = "Uus jalgratas Merida Race 880-16", Name = "Merida Race 880-16", Price = 1700, Image = "assets/images/bicycles/bicycle5.jpg", ProductCategory = categories[4], Stock = 7},
                new ProductData{Id = "25", Description = "Uus jalgratas Merida Race Lite 905", Name = "Merida Race Lite 905", Price = 1200, Image = "assets/images/bicycles/bicycle6.jpg", ProductCategory = categories[4], Stock = 6},

                new ProductData{Id = "26", Description = "Techlite L5T", Name = "Techlite L5T", Price = 800, Image = "assets/images/scooters/scooter1.jpg", ProductCategory = categories[2], Stock = 12},
                new ProductData{Id = "27", Description = "Razor A5 trikitõukeratas", Name = "Razor A5", Price = 650, Image = "assets/images/scooters/scooter2.jpg", ProductCategory = categories[2], Stock = 8},

                new ProductData{Id = "28", Description = "Uus Vans x Ralph Steadman rula" , Name = "Vans x Ralph Steadman", Price = 330, Image = "assets/images/skateboards/skateboard3.jpg", ProductCategory = categories[3], Stock = 10},
                new ProductData{Id = "29", Description = "Uus Vans x Outdoor Gear rula", Name = "Vans x Outdoor Gear", Price = 270, Image = "assets/images/skateboards/skateboard4.jpg", ProductCategory = categories[3], Stock = 15},


            };

            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
}
