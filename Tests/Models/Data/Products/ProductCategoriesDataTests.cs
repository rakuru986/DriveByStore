using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.Data.Common;
using Models.Data.Products;

namespace Tests.Models.Data.Products
{

    [TestClass]
    public class ProductCategoriesDataTests:SealedTests<ProductCategoriesData, UniqueEntityData>
    {
        [TestMethod] public void NameTest() => isNullableProperty<string>();
    }
}
