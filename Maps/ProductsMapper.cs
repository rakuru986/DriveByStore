using System.Threading.Tasks;
using Models.Data;
using Models.Store;
using Services;
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
                Stock = product.stock
        };
            return new Product(productItem);
        }
    }
}
