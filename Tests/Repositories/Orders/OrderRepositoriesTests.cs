using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.Common;
using Models.Context;
using Models.Data.Common;
using Repositories.Common;
using Util.Random;

namespace Tests.Repositories.Orders
{
    public abstract class
        OrderRepositoriesTests<TRepository, TDomain, TData> : SealedTests<TRepository,

            BaseRepository<TDomain, TData>>
        where TRepository : BaseRepository<TDomain, TData>
        where TData : UniqueEntityData, new()
        where TDomain : Entity<TData>
    {

        protected StoreDbContext db;

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            var options = new DbContextOptionsBuilder<StoreDbContext>().UseInMemoryDatabase("TestDb").Options;
            db = new StoreDbContext(options);
        }

        [TestMethod]
        public void CanSetContextAndSetTest()
        {
            obj = getObject(db);
            Assert.AreSame(db, obj.db);
            Assert.AreSame(getSet(db), obj.dbSet);
        }

        protected abstract TRepository getObject(StoreDbContext db);

        protected abstract DbSet<TData> getSet(StoreDbContext db);

        [TestMethod]
        public void ToDomainObjectTest()
        {
            var d = (TData)GetRandom.Object(typeof(TData));
            var o = obj.toModelObject(d);
            arePropertiesEqual(d, o.Data);
        }

    }
}
