using DriveByStore.Data;
using Microsoft.EntityFrameworkCore;

namespace DriveByStore.Infra
{
    public class StoreDbContext : DbContext
    {
        public DbSet<OrderData> Orders { get; set; }
        public DbSet<ProductCategoriesData> ProductCategories{ get; set; }
        public DbSet<ProductData> Products{ get; set; }
        public DbSet<ShoppingCartItemData> ShoppingCartItems { get; set; }
        public DbSet<UserData> Users { get; set; }
        public StoreDbContext(DbContextOptions<StoreDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            InitializeTables(builder);
        }

        public static void InitializeTables(ModelBuilder builder)
        {
            if (builder is null) return;
            builder.Entity<OrderData>().ToTable(nameof(Orders));
            builder.Entity<ProductCategoriesData>().ToTable(nameof(ProductCategories));
            builder.Entity<ProductData>().ToTable(nameof(Products));
            builder.Entity<ShoppingCartItemData>().ToTable(nameof(ShoppingCartItems));
            builder.Entity<UserData>().ToTable(nameof(Users));
        }
    }
}
