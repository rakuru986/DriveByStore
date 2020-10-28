using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models.Context;
using Models.Data;
using Models.Store;
using Models.Store.Interfaces;
using Repositories.Common;

namespace Repositories
{
    public sealed class ProductRepository : UniqueEntityRepository<Product, ProductData>, IProductRepository
    {
        private StoreDbContext db;
        public ProductRepository() : this(null) { }

        public ProductRepository(StoreDbContext c = null) : base(c, c?.Products)
        {
            db = c;
        }

        protected internal override Product toModelObject(ProductData d) => new Product(d);

        protected internal override IQueryable<ProductData> createSqlQuery()
        {
            return db.Products.Include(c => c.ProductCategory);
        }
    }
}
