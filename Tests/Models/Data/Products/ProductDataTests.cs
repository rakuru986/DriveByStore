using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.Data;
using Models.Data.Common;
using System;

namespace Tests.Models.Data.Products
{

    [TestClass]
    public class ProductDataTests : SealedTests<ProductData, UniqueEntityData>
    {

        [TestMethod] public void NameTest() => isNullableProperty<string>();
        [TestMethod] public void PriceTest() => isNullableProperty<double>();
        [TestMethod] public void ImageTest() => isNullableProperty<string>();
        [TestMethod] public void ProductCategoryIdTest() => isNullableProperty<string>();
        [TestMethod] public void ProductCategoryTest() => isProperty<ProductCategoriesData>();
        [TestMethod] public void StockTest() => isProperty<int>();
        [TestMethod] public void DescriptionTest() => isProperty<string>();


    }

}