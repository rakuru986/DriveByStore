using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.Common;
using Models.Data.Common;
using Models.Data.Products;
using Models.Store;
using Util.Random;

namespace Tests.Models.Store {

    [TestClass]
    public class ProductTests : SealedTests<Product, UniqueEntity<ProductData>> {}

}