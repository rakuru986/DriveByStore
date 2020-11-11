using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.Data;
using Models.Store;
using Repositories.Common;

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

            protected internal override Order toModelObject(OrderData d) => MeasureFactory.Create(d);

            protected override async Task<OrderData> getData(string id)
            {
                await Task.CompletedTask;

                return await dbSet.FindAsync(id);
            }

            protected override OrderData getDataById(OrderData d) => dbSet.Find(d.Id);

        }
    }
}
