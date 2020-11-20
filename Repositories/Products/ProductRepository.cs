using System.Linq;
using Microsoft.EntityFrameworkCore;
using Models.Context;
using Models.Data;
using Models.Store;
using Models.Store.Interfaces;
using Repositories.Common;

namespace Repositories.Products
{
    public sealed class ProductRepository : UniqueEntityRepository<Product, ProductData>, IProductRepository
    {
        private readonly StoreDbContext dbc;
        public ProductRepository() : this(null) { }

        public ProductRepository(StoreDbContext c = null) : base(c, c?.Products)
        {
            dbc = c;
        }

        protected internal override Product toModelObject(ProductData d) => new Product(d);

        protected internal override IQueryable<ProductData> createSqlQuery()
        {
            return dbc.Products.Include(c => c.ProductCategory);
        }
    }
}
