using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using Maps;
using Microsoft.AspNetCore.Mvc;
using Models.Data;
using Models.Store;
using ViewModels;

namespace Controllers
{
    public class ProductController : Controller
    {
        // [Route("api/products")]
        // product/GetAllProducts
        public JsonResult GetAllProducts()
        {
            var products = new List<ProductData>()
            {
                new ProductData{Id = "1", Description = "Kiire auto", Name = "Ferrari F12", Price = 320000, ProductCategoryId = "1", Stock = 5},
                new ProductData{Id = "2", Description = "Aeglane auto", Name = "Mazda 6", Price = 2000, ProductCategoryId = "1", Stock = 3},
                new ProductData{Id = "3", Description = "Luksuslik auto", Name = "Rolls-Royce Phantom", Price = 500000, ProductCategoryId = "1", Stock = 2},
                new ProductData{Id = "4", Description = "Tavaline motikas", Name = "Honda CB 1300", Price = 5999, ProductCategoryId = "2", Stock = 8},
                new ProductData{Id = "5", Description = "Vinge rula", Name = "Rimi rula", Price = 99, ProductCategoryId = "4", Stock = 50},
                new ProductData{Id = "6", Description = "Linna jalgratas", Name = "Merida Tour 3", Price = 399, ProductCategoryId = "3", Stock = 30},
                new ProductData{Id = "7", Description = "Elektri tõukeratas", Name = "Bolt scooter", Price = 1200, ProductCategoryId = "5", Stock = 21},
                new ProductData{Id = "8", Description = "Kruvikeeraja", Name = "Kruvikeeraja c99", Price = 12, ProductCategoryId = "6", Stock = 120}
            };

            return Json(products);
        }

        public JsonResult SaveProduct(ProductViewModel product)
        {
            try
            {
                ProductsMapper mapper = new ProductsMapper();
                Product productItem = mapper.mapProducts(product);
                return Json("Successful!");
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }

        }
    }
}
