﻿using System.Threading.Tasks;
using DriveByStore.Data.Common;
using DriveByStore.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace DriveByStore.Infra
{
    public abstract class UniqueEntityRepository<TDomain, TData> : PaginatedRepository<TDomain, TData>
        where TData : UniqueEntityData, new()
        where TDomain : Entity<TData>, new()
    {
        protected UniqueEntityRepository(DbContext c, DbSet<TData> s) : base(c, s) { }

        protected override async Task<TData> GetData(string id)
            => await dbSet.FirstOrDefaultAsync(m => m.Id == id);

        protected override string GetId(TDomain entity) => entity.Data.Id;
    }
}