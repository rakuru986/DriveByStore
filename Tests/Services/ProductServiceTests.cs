using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.Data.Products;
using Models.Store;
using Services;
using Util;
using Util.Random;

namespace Tests.Services
{
    [TestClass]
    public class ProductServiceTests
    {
        private ProductService productService;

        [TestInitialize]
        public void TestInitialize()
        {
            productService = new ProductService();
        }
        [TestMethod]
        public void changeStockTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void getUpdatedProductTest()
        {
            var product = new Product(GetRandom.Object<ProductData>());
            var changeCount = GetRandom.Int32(0, 100);
            var increasedProduct = productService.getUpdatedProduct(product, changeCount, Constants.ADD);
            Assert.AreEqual(product.Data.Stock+changeCount, increasedProduct.Data.Stock);
            var decreasedProduct = productService.getUpdatedProduct(product, changeCount, Constants.REDUCE);
            Assert.AreEqual(product.Data.Stock-changeCount, decreasedProduct.Data.Stock);
        }
    }
}