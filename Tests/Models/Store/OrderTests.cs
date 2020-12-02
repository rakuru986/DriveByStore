using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.Common;
using Models.Data.Orders;
using Models.Store;

namespace Tests.Models.Store {

    [TestClass] public class OrderTests : SealedTests<Order, UniqueEntity<OrderData>> { }

}
