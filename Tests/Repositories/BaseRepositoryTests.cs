using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.Context;
using Models.Data;
using Models.Store;
using Repositories.Common;
using Util.Random;

namespace Tests.Repositories
{
    [TestClass]
    public class BaseRepositoryTests
        : AbstractClassTests<BaseRepository<Order, OrderData>, object>
    {

        private class testClass : BaseRepository<Order, OrderData>
        {

            public testClass(DbContext c, DbSet<OrderData> s) : base(c, s)
            {
            }

            protected internal override Order toModelObject(OrderData d) => new Order(d);

            protected override async Task<OrderData> getData(string id)
            {
                await Task.CompletedTask;

                return await dbSet.FindAsync(id);
            }

            protected override OrderData getDataById(OrderData d) => dbSet.Find(d.Id);

        }
        
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            var options = new DbContextOptionsBuilder<StoreDbContext>().UseInMemoryDatabase("TestDb").Options;
            var c = new StoreDbContext(options);
            obj = new testClass(c, c.Orders);
        }

        [TestMethod]
        public void GetTest()
        {
            var d = GetRandom.Object<OrderData>();
            var o = obj.Get(d.Id).GetAwaiter().GetResult();
            Assert.IsNotNull(o);
            obj.dbSet.Add(d);
            o = obj.Get(d.Id).GetAwaiter().GetResult();
            Assert.IsNotNull(o);
            Assert.IsInstanceOfType(o, typeof(Order));
            arePropertiesEqual(d, o.Data);
        }
    }
}
