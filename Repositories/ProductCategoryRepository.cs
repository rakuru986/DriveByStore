using Microsoft.EntityFrameworkCore;
using Models.Context;
using Models.Data;
using Models.Store;
using Models.Store.Interfaces;
using Repositories.Common;

namespace Repositories
{
    public sealed class ProductCategoryRepository : UniqueEntityRepository<ProductCategory, ProductCategoriesData>, IProductCategoryRepository
    {
        public ProductCategoryRepository(StoreDbContext context) : base(context, context?.ProductCategories) { }

        protected internal override ProductCategory toModelObject(ProductCategoriesData d) => new ProductCategory(d);
    }
}
