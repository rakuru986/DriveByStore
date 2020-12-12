using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.Context;
using Models.Data.Products;
using Models.Store;
using Repositories.Common;
using Repositories.Products;

namespace Tests.Repositories.Products
{

    [TestClass]
    public class ProductCategoryRepositoryTests : ProductRepositoriesTests<ProductCategoryRepository,
        ProductCategory, ProductCategoriesData>
    {

        protected override Type getBaseClass() => typeof(UniqueEntityRepository<ProductCategory, ProductCategoriesData>);

        protected override ProductCategoryRepository getObject(StoreDbContext c) =>
            new ProductCategoryRepository(c);

        protected override DbSet<ProductCategoriesData> getSet(StoreDbContext c) => c.ProductCategories;

    }

}