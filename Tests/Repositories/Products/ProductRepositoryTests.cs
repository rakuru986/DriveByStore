//using System;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Models.Data;
//using Models.Store.Interfaces;
//using Repositories;
//using Repositories.Common;
//using Repositories.Products;
//using Util;

//namespace Tests.Repositories.Products
//{
//    [TestClass]
//    public class ProductRepositoryTests : ProductRepositoriesTests<ProductRepository,
//        IProductRepository, ProductData>
//    {

//        protected override Type getBaseClass() => typeof(UniqueEntityRepository<IProduct, ProductData>);

//        protected override ProductsRepository getObject(ProductDbContext c) => new ProductsRepository(c);

//        protected override DbSet<ProductData> getSet(ProductDbContext c) => c.Products;

//    }

//}

