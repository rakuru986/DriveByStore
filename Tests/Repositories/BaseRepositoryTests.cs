using System.Threading.Tasks;
using Abc.Tests;
using Microsoft.EntityFrameworkCore;
using Models.Data;
using Models.Store;
using Repositories.Common;

namespace Tests.Repositories
{
    class BaseRepositoryTests:AbstractClassTests<BaseRepository<Order, OrderData>, object>
    {
        private OrderData data;
        private class testClass : BaseRepository<Order, OrderData>
        {
            public testClass(DbContext c, DbSet<OrderData> s) : base(c, s)
            {
            }

            protected override Order toModelObject(OrderData d) => new Order(d);

            protected override async Task<OrderData> getData(string id)
            {
                return await dbSet.FirstOrDefaultAsync(m => m.Id == id);
            }

            protected override OrderData getDataById(OrderData entity) => entity?.User?.Id;

        }
        

    }
}
