using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Repositories.Interfaces;
using Services.Interfaces;
using Util;
using ViewModels;

namespace Soft.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository productRepository;
        private readonly IMapperService mapper;
        private readonly IProductService service;

        public ProductController(IProductRepository p, IMapperService ms, IProductService ps)
        {
            productRepository = p;
            mapper = ms;
            service = ps;
        }

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

            var isSuccessfulUpdate = await service.changeStock(item.productId, item.changeCount, item.mode, productRepository);
            return isSuccessfulUpdate
                ? Json(Ok("Update successful"))
                : Json(BadRequest("Item with given id not found"));
        }
    }
}
