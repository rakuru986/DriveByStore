using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.Context;
using Models.Data.Orders;
using Models.Store;
using Repositories.Common;
using Repositories.Orders;

namespace Tests.Repositories.Orders
{
    [TestClass]
    public class OrderDetailsRepositoryTests : OrderRepositoriesTests<OrderDetailsRepository,
        OrderDetails, OrderDetailsData>
    {

        protected override Type getBaseClass() => typeof(UniqueEntityRepository<OrderDetails, OrderDetailsData>);

        protected override OrderDetailsRepository getObject(StoreDbContext c) =>
            new OrderDetailsRepository(c);

        protected override DbSet<OrderDetailsData> getSet(StoreDbContext c) => c.OrderDetails;

    }
}
