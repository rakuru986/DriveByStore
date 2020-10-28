using System;
using System.Collections.Generic;
using Maps;
using Microsoft.AspNetCore.Mvc;
using Models.Data;
using Models.Store;
using Models.Store.Interfaces;
using Util;
using ViewModels;

namespace Soft.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository productRepository;
        private readonly IProductCategoryRepository productCategoryRepository;

        public ProductController(IProductRepository p, IProductCategoryRepository pc)
        {
            productRepository = p;
            productCategoryRepository = pc;
        }
        // [Route("api/products")]
        // product/GetAllProducts
        public JsonResult GetAllProducts()
        {
            var products = productRepository.Get().Result;
            foreach (var product in products)
            {
                if (product.Data.ProductCategoryId == null) continue;
                var category = productCategoryRepository.Get(product.Data.ProductCategoryId).Result;
            }
            return Json(products);
        }

        public JsonResult SaveProduct(ProductViewModel product)
        {
            try
            {
                ProductsMapper mapper = new ProductsMapper();
                Product productItem = mapper.mapProducts(product);
                productRepository.Add(productItem);
                return Json("Successful!");
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }

        }
    }
}
