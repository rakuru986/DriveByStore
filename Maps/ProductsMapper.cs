using Models.Data;
using Models.Store;
using ViewModels;

namespace Maps
{
    public class ProductsMapper
    {
        public Product mapProducts(ProductViewModel product)
        {
            ProductData productItem = new ProductData
            {
                Name = product.name,
                Description = product.description,
                Image = product.image,
                Price = product.price,
                Stock = product.stock,
                ProductCategoryId = product.categoryId
        };
            return new Product(productItem);
        }
    }
}
