using System.Threading.Tasks;
using Maps;
using Microsoft.AspNetCore.Mvc;
using Models.Store;
using Models.Store.Interfaces;
using Services;
using Util;
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

        // product/GetAllProducts
        public JsonResult GetAllProducts()
        {
            var products = productRepository.Get().Result;
            return Json(products);
        }

        [HttpPost]
        public async Task<IActionResult> SaveProduct([FromBody]SaveProductViewModel product)
        {
            if (product == null)
            {
                return Json(BadRequest());
            }
            ProductsMapper mapper = new ProductsMapper();
            Product productItem = mapper.mapSaveProduct(product);
            await productRepository.Add(productItem);
            return Json(Ok(productItem));
        }

        [HttpPost]
        public async Task<IActionResult> ReduceStock([FromBody] ChangeStockViewModel item)
        {
            if (item.mode != Constants.ADD && item.mode != Constants.REDUCE) { return Json(BadRequest("Invalid mode")); }

            var product = await productRepository.Get(item.productId);

            if (product.Id == Constants.Unspecified) return Json(BadRequest("Item with given id not found"));

            var service = new ProductService();
            var updatedProduct = service.changeStock(product, item.changeCount, item.mode);
            await productRepository.Update(updatedProduct);
            return Json(Ok(updatedProduct.Data.Stock));
        }
    }
}
