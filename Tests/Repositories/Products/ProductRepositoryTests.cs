using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.Store.Interfaces;
using Repositories;
using Util;

namespace Tests.Repositories.Products
{
    [TestClass]
    public class ProductRepositoryTests : BaseSoftTests
    {

        [TestInitialize] public void TestInitialize() => type = typeof(ProductRepository);

        [DataTestMethod]
        [DataRow(typeof(IProductRepository))]
        [DataRow(typeof(IProductCategoryRepository))]
        public void RegisterTest(Type t) => Assert.IsNotNull(GetRepository.Instance(t));

    }

}

