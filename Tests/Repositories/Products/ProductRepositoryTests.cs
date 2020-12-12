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
    public class ProductRepositoryTests : ProductRepositoriesTests<ProductRepository,
        Product, ProductData>
    {

        protected override Type getBaseClass() => typeof(UniqueEntityRepository<Product, ProductData>);

        protected override ProductRepository getObject(StoreDbContext c) => new ProductRepository(c);

        protected override DbSet<ProductData> getSet(StoreDbContext c) => c.Products;

    }

}

