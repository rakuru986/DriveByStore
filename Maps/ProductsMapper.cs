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
            Product productItem = new Product(new ProductData());
            productItem.Data.Name = product.name;
            productItem.Data.Description = product.description;
            productItem.Data.Image = product.image;
            productItem.Data.Price = product.price;
            productItem.Data.Stock = product.stock;
            ProductService service = new ProductService();
            service.modifyProduct(productItem);
            return productItem;
        }
    }
}
