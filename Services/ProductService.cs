using Models.Data;
using Models.Data.Products;
using Models.Store;
using Repositories.Interfaces;
using Services.Interfaces;
using Util;

namespace Services
{
    public class ProductService : IProductService
    {
        public async Task<bool> changeStock(string productId, int changeCount, string mode, IProductRepository pr)
        {
            var product = await pr.Get(productId);

            if (product.Id == Constants.Unspecified) return false;

            var updatedProduct = getUpdatedProduct(product, changeCount, mode);
            await pr.Update(updatedProduct);
            return true;
        }

        private Product getUpdatedProduct(Product product, int changeCount, string mode)
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
