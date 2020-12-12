using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.Data.Orders;
using Models.Store;
using Repositories.Common;

namespace Tests.Repositories.Common {

    [TestClass]
    public class UniqueEntityRepositoryTests : AbstractClassTests<UniqueEntityRepository<Order, OrderData>, 
        BaseRepository<Order, OrderData>>
    {

        private class testClass : UniqueEntityRepository<Order, OrderData> {

            public testClass(DbContext c, DbSet<OrderData> s) : base(c, s) { }

            protected internal override Order toModelObject(OrderData d) => new Order(d);
        }

        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            obj = new testClass(null, null);
        }

    }

}
