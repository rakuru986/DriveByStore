//using Microsoft.EntityFrameworkCore;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Models.Common.Interfaces;
//using Util.Random;

//namespace Tests.Repositories.Products {

//    public abstract class
//        ProductRepositoryTests<TRepository, TDomain, TData> : SealedTests<TRepository,
//            PaginatedRepository<TDomain, TData>>
//        where TRepository : PaginatedRepository<TDomain, TData>
//        where TData : PeriodData, new()
//        where TDomain : IEntity<TData> {

//        protected ProductDbContext db;

//        [TestInitialize] public override void TestInitialize() {
//            base.TestInitialize();
//            var options = new DbContextOptionsBuilder<ProductDbContext>().UseInMemoryDatabase("TestDb").Options;
//            db = new ProductDbContext(options);
//        }

//        [TestMethod] public void CanSetContextAndSetTest() {
//            obj = getObject(db);
//            Assert.AreSame(db, obj.db);
//            Assert.AreSame(getSet(db), obj.dbSet);
//        }

//        protected abstract TRepository getObject(ProductDbContext db);

//        protected abstract DbSet<TData> getSet(ProductDbContext db);

//        [TestMethod] public virtual void ToDomainObjectTest() {
//            var d = (TData) GetRandom.Object(typeof(TData));
//            var o = obj.toDomainObject(d);
//            arePropertiesEqual(d, o.Data);
//        }

//    }

//}

