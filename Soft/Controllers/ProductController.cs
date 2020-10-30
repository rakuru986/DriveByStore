using System;
using System.Collections.Generic;
using Maps;
using Microsoft.AspNetCore.Mvc;
using Models.Data;
using Models.Store;
using Models.Store.Interfaces;
using ViewModels;

namespace Soft.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository p)
        {
            productRepository = p;
        }

        // [Route("api/products")]
        // product/GetAllProducts
        public JsonResult GetAllProducts()
        {
            var products = productRepository.Get().Result;
            return Json(products);
        }

        public JsonResult SaveProduct([FromBody]ProductViewModel product)
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
