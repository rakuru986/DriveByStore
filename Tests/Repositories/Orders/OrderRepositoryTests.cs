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
    public class OrderRepositoryTests : OrderRepositoriesTests<OrderRepository,
        Order, OrderData>
    {

        protected override Type getBaseClass() => typeof(UniqueEntityRepository<Order, OrderData>);

        protected override OrderRepository getObject(StoreDbContext c) =>
            new OrderRepository(c);

        protected override DbSet<OrderData> getSet(StoreDbContext c) => c.Orders;

    }


}

