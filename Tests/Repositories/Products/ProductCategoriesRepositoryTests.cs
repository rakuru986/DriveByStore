//using System;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Models.Data;
//using Models.Store;
//using Repositories;
//using Repositories.Common;

//namespace Tests.Repositories.Products {

//    [TestClass] public class ProductCategoriesRepositoryTests : ProductRepositoryTests<ProductCategoryRepository,
//        ProductCategory, ProductCategoriesData> {

//        protected override Type getBaseClass() => typeof(UniqueEntityRepository<ProductCategory, ProductCategoryData>);

//        protected override ProductCategoriesRepository getObject(ProductDbContext c) =>
//            new ProductCategoriesRepository(c);

//        protected override DbSet<ProductCategoryData> getSet(ProductDbContext c) => c.ProductCategories;

//    }

//}