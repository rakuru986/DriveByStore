﻿using System;
using System.Linq;
using System.Linq.Expressions;
using DriveByStore.Data.Common;
using DriveByStore.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace DriveByStore.Infra
{
    public abstract class FilteredRepository<TDomain, TData> : SortedRepository<TDomain, TData>, IFiltering
        where TData : NamedEntityData, new()
        where TDomain : Entity<TData>, new()
    {
        public string SearchString { get; set; }
        public string FixedFilter { get; set; }
        public string FixedValue { get; set; }

        protected FilteredRepository(DbContext c, DbSet<TData> s) : base(c, s) { }

        protected internal override IQueryable<TData> CreateSqlQuery()
        {
            var query = base.CreateSqlQuery();
            query = AddFixedFiltering(query);
            query = AddFiltering(query);
            return query;
        }

        internal IQueryable<TData> AddFixedFiltering(IQueryable<TData> query)
        {
            var expression = CreateFixedWhereExpression();
            return (expression is null) ? query : query.Where(expression);
        }

        internal Expression<Func<TData, bool>> CreateFixedWhereExpression()
        {
            if (string.IsNullOrWhiteSpace(FixedFilter)) return null;
            if (string.IsNullOrWhiteSpace(FixedValue)) return null;
            var param = Expression.Parameter(typeof(TData), "s");

            var p = typeof(TData).GetProperty(FixedFilter);
            if (p is null) return null;
            Expression body = Expression.Property(param, p);
            if (p.PropertyType != typeof(string))
                body = Expression.Call(body, "ToString", null);
            body = Expression.Equal(body, Expression.Constant(FixedValue));
            var predicate = body;

            return Expression.Lambda<Func<TData, bool>>(predicate, param);
        }

        internal IQueryable<TData> AddFiltering(IQueryable<TData> query)
        {
            if (string.IsNullOrEmpty(SearchString)) return query;
            var expression = CreateWhereExpression();
            return (expression is null) ? query : query.Where(expression);
        }

        internal Expression<Func<TData, bool>> CreateWhereExpression()
        {
            if (string.IsNullOrWhiteSpace(SearchString)) return null;

            var param = Expression.Parameter(typeof(TData), "s");
            Expression predicate = null;
            foreach (var p in typeof(TData).GetProperties())
            {
                Expression body = Expression.Property(param, p);
                if (p.PropertyType != typeof(string))
                    body = Expression.Call(body, "ToString", null);
                body = Expression.Call(body, "Contains", null, Expression.Constant(SearchString));
                predicate = predicate is null ? body : Expression.Or(predicate, body);
            }

            return predicate is null ? null : Expression.Lambda<Func<TData, bool>>(predicate, param);
        }
    }
}