using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.Context;
using Models.Data;
using Models.Store;
using Models.Store.Interfaces;
using Repositories;
using Repositories.Common;

namespace Tests.Repositories.Orders {

    [TestClass]
    public class
        OrderRepositoryTests : SealedTests<OrderRepository,object>
    {
        protected override Type getBaseClass() => typeof(UniqueEntityRepository<Order, OrderData>);

      

    }


}

