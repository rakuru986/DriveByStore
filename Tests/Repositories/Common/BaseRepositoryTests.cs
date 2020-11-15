using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.Context;
using Models.Data;
using Models.Store;
using Repositories.Common;
using Util.Random;

namespace Tests.Repositories.Common
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

        [TestMethod]
        public void DeleteTest()
        {
            var d = GetRandom.Object<OrderData>();
            obj.dbSet.Add(d);
            var o = obj.Get(d.Id).GetAwaiter().GetResult();
            Assert.IsNotNull(o);
            //obj.Delete(d.Id).GetAwaiter();
            //o = obj.Get(d.Id).GetAwaiter().GetResult();
            ////Assert.IsTrue(o.IsUnspecified);
        }

        [TestMethod]
        public void AddTest()
        {
            var d = GetRandom.Object<OrderData>();
            var o = obj.Get(d.Id).GetAwaiter().GetResult();
            //Assert.IsTrue(o.IsUnspecified);
            obj.Add(new Order(d)).GetAwaiter();
            o = obj.Get(d.Id).GetAwaiter().GetResult();
            arePropertiesEqual(d, o.Data);
        }
        [TestMethod]
        public void UpdateTest()
        {
            var d = GetRandom.Object<OrderData>();
            var d1 = GetRandom.Object<OrderData>();
            obj.Add(new Order()).GetAwaiter();
            d1.Id = d.Id;
            obj.Update(new Order(d)).GetAwaiter();
            var o = obj.Get(d.Id).GetAwaiter().GetResult();
            arePropertiesEqual(d1, o.Data);
        }
        [TestMethod]
        public void GetListTest()
        {
            for (var i = 0; i < GetRandom.UInt8(10, 30); i++)
            {
                var d = GetRandom.Object<OrderData>();
                obj.Add(new Order(d)).GetAwaiter();
            }

            var l = obj.Get().GetAwaiter().GetResult();
            Assert.AreEqual(obj.dbSet.Count(), l.Count);
        }

        [TestMethod]
        public void GetByIdTest()
        {
            OrderData data = new OrderData();
            var count = GetRandom.UInt8(10, 30);
            var idx = GetRandom.UInt8(0, count);

            for (var i = 0; i < count; i++)
            {
                var d = GetRandom.Object<OrderData>();
                if (i == idx) data = d;
                obj.Add(new Order(d)).GetAwaiter();
            }

            var m = obj.GetById(data.Id) as Order;
            Assert.IsNotNull(m);
            arePropertiesEqual(data, m.Data);
        }


    }
}
