using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.Data;
using Models.Data.Common;
using Models.Data.Inventory;
using Models.Data.Products;

namespace Tests.Models.Data.Inventory
{
    [TestClass]
    public class InventoryDataTests : SealedTests<InventoryData, UniqueEntityData>
    {
        [TestMethod] public void ProductIdTest() => isNullableProperty<string>();
        [TestMethod] public void ProductTest() => isProperty<ProductData>();
        [TestMethod] public void StockTest() => isProperty<int>();
        

    }
}
