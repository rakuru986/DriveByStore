using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models.Common.Interfaces;
using Models.Data.Common;

namespace Repositories.Common
{
    public abstract class UniqueEntityRepository<TModel, TData> : BaseRepository<TModel, TData>
        where TModel : IEntity<TData>
        where TData : UniqueEntityData, new()
    {
        protected UniqueEntityRepository(DbContext context, DbSet<TData> set) : base(context, set) { }

        protected override async Task<TData> getData(string id) => await dbSet.FirstOrDefaultAsync(m => m.Id == id);

        protected override TData getDataById(TData d) => dbSet.Find(d.Id);
    }
}
