using Microsoft.EntityFrameworkCore;
using Models.Data;

namespace Models.Context
{
    public class StoreDbContext : DbContext
    {
        public DbSet<InventoryData> Inventory { get; set; }
        public DbSet<OrderData> Orders { get; set; }
        public DbSet<OrderDetailsData> OrderDetails { get; set; }
        public DbSet<ProductCategoriesData> ProductCategories { get; set; }
        public DbSet<ProductData> Products { get; set; }

        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            InitializeTables(builder);
            StoreDbInitializer.Initialize(this);
        }

        public static void InitializeTables(ModelBuilder builder)
        {
            if (builder is null) return;
            builder.Entity<InventoryData>().ToTable(nameof(Inventory));
            builder.Entity<OrderData>().ToTable(nameof(Orders));
            builder.Entity<OrderDetailsData>().ToTable(nameof(OrderDetails));
            builder.Entity<ProductCategoriesData>().ToTable(nameof(ProductCategories));
            builder.Entity<ProductData>().ToTable(nameof(Products));

        }
    }
}
