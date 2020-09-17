using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DriveByStore.Data.Common;
using DriveByStore.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace DriveByStore.Infra
{
    public abstract class BaseRepository<TDomain, TData> : ICrudMethods<TDomain>
        where TData : NamedEntityData, new()
        where TDomain : Entity<TData>, new()
    {
        protected internal DbContext db;
        protected internal DbSet<TData> dbSet;

        protected BaseRepository(DbContext c, DbSet<TData> s)
        {
            db = c;
            dbSet = s;
        }

        public virtual async Task<List<TDomain>> Get()
        {
            var query = CreateSqlQuery();
            var set = await RunSqlQueryAsync(query);
            return ToDomainObjectsList(set);
        }

        public async Task<TDomain> Get(string id)
        {
            if (id is null) return new TDomain();
            var d = await GetData(id);
            var obj = ToDomainObject(d);

            return obj;
        }

        public async Task Delete(string id)
        {
            if (id is null) return;
            var d = await GetData(id);

            if (d is null) return;
            dbSet.Remove(d);
            await db.SaveChangesAsync();
        }

        public async Task Add(TDomain obj)
        {
            if (obj?.Data is null) return;
            dbSet.Add(obj.Data);
            await db.SaveChangesAsync();
        }

        public async Task Update(TDomain obj)
        {
            if (obj is null) return;
            var d = await GetData(GetId(obj));
            if (d is null) return;
            dbSet.Remove(d);
            dbSet.Add(obj.Data);
            await db.SaveChangesAsync();
        }
        internal async Task<List<TData>> RunSqlQueryAsync(IQueryable<TData> query) => await query.AsNoTracking().ToListAsync();

        protected internal virtual IQueryable<TData> CreateSqlQuery()
        {
            var query = from s in dbSet select s;
            return query;
        }

        internal List<TDomain> ToDomainObjectsList(List<TData> set) => set.Select(ToDomainObject).ToList();
        protected internal abstract TDomain ToDomainObject(TData periodData);
        protected abstract Task<TData> GetData(string id);
        protected abstract string GetId(TDomain entity);
    }
}