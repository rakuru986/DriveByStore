using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.Common.Interfaces;
using Models.Context;
using Models.Data;
using Models.Data.Orders;
using Models.Store;
using Repositories;
using Repositories.Common;
using Repositories.Orders;
using Tests.Repositories.Products;
using Util.Random;

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
