using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.Common;
using Models.Data.Inventory;
using Models.Store;

namespace Tests.Models.Store
{
    [TestClass] public class InventoryTests : SealedTests<Inventory, UniqueEntity<InventoryData>> { }
}
