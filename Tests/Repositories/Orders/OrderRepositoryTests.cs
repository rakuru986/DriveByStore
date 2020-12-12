using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.Data.Orders;
using Models.Store;
using Repositories.Common;
using Repositories.Orders;

namespace Tests.Repositories.Orders {

    [TestClass]
    public class
        OrderRepositoryTests : SealedTests<OrderRepository,object>
    {
        protected override Type getBaseClass() => typeof(UniqueEntityRepository<Order, OrderData>);

      

    }


}

