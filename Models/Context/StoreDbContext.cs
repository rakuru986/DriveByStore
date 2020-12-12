using Microsoft.EntityFrameworkCore;
using Models.Data.Orders;
using Models.Data.Products;
using Models.Data.Users;

namespace Models.Context
{
    public class StoreDbContext : DbContext
    {
        public DbSet<OrderData> Orders { get; set; }
        public DbSet<OrderDetailsData> OrderDetails { get; set; }
        public DbSet<ProductCategoriesData> ProductCategories { get; set; }
        public DbSet<ProductData> Products { get; set; }
        public DbSet<UserData> Users { get; set; }

        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            InitializeTables(builder);
        }

        public static void InitializeTables(ModelBuilder builder)
        {
            if (builder is null) return;

            builder.Entity<OrderData>().ToTable(nameof(Orders));

            builder.Entity<OrderDetailsData>().HasOne(c => c.Order).WithMany().HasForeignKey(c => c.OrderId);
            builder.Entity<OrderDetailsData>().HasOne(c => c.Product).WithMany().HasForeignKey(c => c.ProductId);
            builder.Entity<OrderDetailsData>().ToTable(nameof(OrderDetails));

            builder.Entity<ProductCategoriesData>().ToTable(nameof(ProductCategories));

            builder.Entity<ProductData>().HasOne(c => c.ProductCategory).WithMany()
                .HasForeignKey(c => c.ProductCategoryId);
            builder.Entity<ProductData>().ToTable(nameof(Products));
            builder.Entity<UserData>().ToTable(nameof(Users));

        }
    }
}
