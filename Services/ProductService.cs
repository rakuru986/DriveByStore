using Models.Data;
using Models.Store;
using Repositories;
using Util;

namespace Services
{
    public class ProductService
    {
        public Product changeStock(Product product, int changeCount, string mode)
        {
            int newStock = product.Data.Stock;
            if (mode == Constants.ADD) { newStock += changeCount; }
            else if (mode == Constants.REDUCE) { newStock -= changeCount; }

            ProductData newData = new ProductData
            {
                Id = product.Data.Id,
                Name = product.Data.Name,
                Description = product.Data.Description,
                Image = product.Data.Image,
                Price = product.Data.Price,
                ProductCategory = product.Data.ProductCategory,
                ProductCategoryId = product.Data.ProductCategoryId,
                Stock = newStock
            };
            return new Product(newData);
        }
    }
}
