using System.Threading.Tasks;
using Maps;
using Microsoft.AspNetCore.Mvc;
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

        // product/GetAllProducts
        public JsonResult GetAllProducts()
        {
            var products = productRepository.Get().Result;
            return Json(products);
        }

        [HttpPost]
        public async Task<IActionResult> SaveProduct([FromBody]ProductViewModel product)
        {
            if (product == null)
            {
                return Json(BadRequest());
            }
            ProductsMapper mapper = new ProductsMapper();
            Product productItem = mapper.mapProducts(product);
            await productRepository.Add(productItem);
            return Json(Ok(productItem));
        }
    }
}
