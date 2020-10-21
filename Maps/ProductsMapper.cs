using Models.Store;
using ViewModels;

namespace Maps
{
    public class ProductsMapper
    {
        public Product mapProducts(ProductViewModel product)
        {
            Product productItem = new Product();
            productItem.Data.Name = product.name;
            productItem.Data.Description = product.description;
            productItem.Data.Image = product.image;
            productItem.Data.Price = product.price;
            productItem.Data.Stock = product.stock;
            return productItem;
        }
    }
}
