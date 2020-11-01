using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models.Common.Interfaces;
using Models.Data.Common;
using Util;

namespace Repositories.Common
{
    public abstract class BaseRepository<TModel, TData> : ICrudMethods<TModel>, IRepository
        where TModel : IEntity<TData>
        where TData : UniqueEntityData, new()
    {
        protected internal DbContext db;
        protected internal DbSet<TData> dbSet;

        protected BaseRepository(DbContext context, DbSet<TData> set)
        {
            db = context;
            dbSet = set;
        }

        public virtual async Task<List<TModel>> Get()
        {
            var query = createSqlQuery();
            var set = await runSqlQueryAsync(query);

            return toModelObjectsList(set);
        }

        internal List<TModel> toModelObjectsList(List<TData> set) => set.Select(toModelObject).ToList();

        protected internal abstract TModel toModelObject(TData uniqueEntityData);

        internal async Task<List<TData>> runSqlQueryAsync(IQueryable<TData> query) =>
            await query.AsNoTracking().ToListAsync();

        protected internal virtual IQueryable<TData> createSqlQuery()
        {
            var query = from s in dbSet select s;

            return query;
        }

        public async Task<TModel> Get(string id)
        {
            if (id is null) return toModelObject(new TData());

            var d = await getData(id);

            var obj = toModelObject(d);

            return obj;
        }

        protected abstract Task<TData> getData(string id);

        public async Task Delete(string id)
        {
            if (id is null) return;

            var v = await getData(id);

            if (v is null) return;

            dbSet.Remove(v);

            await db.SaveChangesAsync();
        }

        public async Task Add(TModel obj)
        {
            var d = getData(obj);

            if (d is null) return;
            if (isInDatabase(d)) await Update(obj);
            else
            {
                dbSet.Add(d);
                await db.SaveChangesAsync();
            }
        }

        protected bool isInDatabase(TData d) => getDataById(d) != null;

        protected TData getData(TModel obj) => obj.Data;

        public async Task Update(TModel obj)
        {
            var d = getData(obj);
            d = copyData(d);
            db.Attach(d).State = EntityState.Modified;

            await db.SaveChangesAsync();
        }

        private TData copyData(TData d)
        {
            var x = getDataById(d);

            if (x is null) return d;
            Copy.Members(d, x);

            return x;
        }

        protected abstract TData getDataById(TData d);
        public object getById(string id) => Get(id).GetAwaiter().GetResult();
    }
}
