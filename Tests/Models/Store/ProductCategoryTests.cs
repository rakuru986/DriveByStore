using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.Common;
using Models.Data.Products;
using Models.Store;
using Util.Random;

namespace Tests.Models.Store
{

    [TestClass]
    public class ProductCategoryTests : SealedTests<ProductCategory, UniqueEntity<ProductCategoriesData>>
    {

        protected override ProductCategory createObject() =>
            new ProductCategory(GetRandom.Object<ProductCategoriesData>());

    }
}