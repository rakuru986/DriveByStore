using Models.Context;
using Models.Data.Products;
using Models.Store;
using Repositories.Common;
using Repositories.Interfaces;

namespace Repositories.Products
{
    public sealed class ProductCategoryRepository : UniqueEntityRepository<ProductCategory, ProductCategoriesData>, IProductCategoryRepository
    {
        public ProductCategoryRepository(StoreDbContext context) : base(context, context?.ProductCategories) { }

        protected internal override ProductCategory toModelObject(ProductCategoriesData d) => new ProductCategory(d);
    }
}
