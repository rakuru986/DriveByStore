using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Models.Context;
using Models.Data;
using Models.Store;
using Models.Store.Interfaces;
using Repositories.Common;

namespace Repositories
{
    public sealed class ProductRepository : UniqueEntityRepository<Product, ProductData>, IProductRepository
    {
        private StoreDbContext context;
        private string id = "aaa";
        public ProductRepository() : this(null) { }

        public ProductRepository(StoreDbContext c = null) : base(c, c?.Products)
        {
            context = c;
        }

        protected internal override Product toModelObject(ProductData d) => new Product(d);
    }
}
