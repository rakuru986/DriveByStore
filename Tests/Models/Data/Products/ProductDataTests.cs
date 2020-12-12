using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.Data.Common;
using Models.Data.Products;

namespace Tests.Models.Data.Products
{

    [TestClass]
    public class ProductDataTests : SealedTests<ProductData, UniqueEntityData>
    {

        [TestMethod] public void NameTest() => isNullableProperty<string>();
        [TestMethod] public void PriceTest() => isProperty<double>();
        [TestMethod] public void ImageTest() => isNullableProperty<string>();
        [TestMethod] public void ProductCategoryIdTest() => isNullableProperty<string>();
        [TestMethod] public void ProductCategoryTest() => isProperty<ProductCategoriesData>();
        [TestMethod] public void StockTest() => isProperty<int>();
        [TestMethod] public void DescriptionTest() => isNullableProperty<string>();


    }

}