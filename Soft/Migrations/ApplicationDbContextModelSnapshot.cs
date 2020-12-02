﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Soft.Data;

namespace Soft.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Models.Data.Inventory.InventoryData", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProductId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Inventory");
                });

            modelBuilder.Entity("Models.Data.Orders.OrderData", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("OrderCity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrderEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrderPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OrderShippedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrderZip")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShippingAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.Property<string>("TrackingNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Models.Data.Orders.OrderDetailsData", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("OrderId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("ProductId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("Models.Data.Products.ProductCategoriesData", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("Models.Data.Products.ProductData", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("ProductCategoryId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductCategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Models.Data.Users.UserData", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Models.Data.Inventory.InventoryData", b =>
                {
                    b.HasOne("Models.Data.Products.ProductData", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("Models.Data.Orders.OrderData", b =>
                {
                    b.HasOne("Models.Data.Users.UserData", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Models.Data.Orders.OrderDetailsData", b =>
                {
                    b.HasOne("Models.Data.Orders.OrderData", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId");

                    b.HasOne("Models.Data.Products.ProductData", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("Models.Data.Products.ProductData", b =>
                {
                    b.HasOne("Models.Data.Products.ProductCategoriesData", "ProductCategory")
                        .WithMany()
                        .HasForeignKey("ProductCategoryId");
                });
#pragma warning restore 612, 618
        }
    }
}
