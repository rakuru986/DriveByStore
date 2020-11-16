using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.Common.Interfaces;
using Models.Context;
using Models.Data;
using Models.Store;
using Repositories;
using Repositories.Common;
using Tests.Repositories.Products;
using Util.Random;

namespace Tests.Repositories.Orders
{
    public abstract class
        OrderDetailsRepositoryTests<TRepository, TDomain, TData> : SealedTests<TRepository,
            BaseRepository<TDomain, TData>>
        where TRepository : BaseRepository<TDomain, TData>
        where TData : OrderDetailsData, new()
        where TDomain : IEntity<TData>
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
        public virtual void ToDomainObjectTest()
        {
            var d = (TData)GetRandom.Object(typeof(TData));
            var o = obj.toModelObject(d);
            arePropertiesEqual(d, o.Data);
        }
    }
}
