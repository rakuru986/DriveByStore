using Models.Store;
using Repositories;

namespace Services
{
    public class ProductService
    {
        public async void modifyProduct(Product product)
        {
            ProductRepository repo = new ProductRepository();
            await repo.Add(product);
        }
    }
}
