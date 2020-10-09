using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Models.Data;
using Models.Store;

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
                new ProductData{Id = "4", Description = "Maitsev kook", Name = "Napoleoni kook", Price = 12, ProductCategoryId = "2", Stock = 10},
                new ProductData{Id = "5", Description = "Mmmm...", Name = "Šokolaadi muffin", Price = 2, ProductCategoryId = "2", Stock = 15},
                new ProductData{Id = "6", Description = "Jahu küpsetamiseks", Name = "Nisujahu", Price = 1, ProductCategoryId = "2", Stock = 52}
            };

            return Json(products);
        }

        // product/GetString
        public string GetString()
        {
            return "Response from controller.";
        }
    }
}
