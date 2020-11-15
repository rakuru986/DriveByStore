using System.Threading.Tasks;
using Maps;
using Microsoft.AspNetCore.Mvc;
using Models.Store.Interfaces;
using Services;
using Util;
using ViewModels;

namespace Soft.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository productRepository;
        private readonly ProductsMapper mapper;
        private readonly ProductService service;

        public ProductController(IProductRepository p)
        {
            productRepository = p;
            mapper = new ProductsMapper();
            service = new ProductService();
        }

        // product/GetAllProducts
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await productRepository.Get();
            return products == null ? Json(BadRequest("No products found")) : Json(Ok(products));
        }

        [HttpPost]
        public async Task<IActionResult> SaveProduct([FromBody]SaveProductViewModel product)
        {
            if (product == null) return Json(BadRequest());
            var productItem = mapper.mapSaveProduct(product);
            await productRepository.Add(productItem);
            return Json(Ok(productItem));
        }

        [HttpPost]
        public async Task<IActionResult> ReduceStock([FromBody] ChangeStockViewModel item)
        {
            if (item == null) return Json(BadRequest());
            if (item.mode != Constants.ADD && item.mode != Constants.REDUCE) return Json(BadRequest("Invalid mode"));

            var product = await productRepository.Get(item.productId);

            if (product.Id == Constants.Unspecified) return Json(BadRequest("Item with given id not found"));

            var updatedProduct = service.changeStock(product, item.changeCount, item.mode);
            await productRepository.Update(updatedProduct);
            return Json(Ok(updatedProduct.Data.Stock));
        }
    }
}
