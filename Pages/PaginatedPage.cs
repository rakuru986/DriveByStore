﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projekt.Domain.Common;

namespace Projekt.Pages
{
    public abstract class PaginatedPage<TRepository, TDomain, TView, TData> : CrudPage<TRepository, TDomain, TView, TData>
        where TRepository : ICrudMethods<TDomain>, ISorting, IFiltering, IPaging
    {
        protected PaginatedPage(TRepository r) : base(r) { }

        public IList<TView> Items { get; private set; }

        public string SelectedId
        {
            get;
            set;
        }
        public int PageIndex
        {
            get => db.PageIndex;
            set => db.PageIndex = value;
        }
        public bool HasPreviousPage => db.HasPreviousPage;
        public bool HasNextPage => db.HasNextPage;

        public int TotalPages => db.TotalPages;

        protected internal override void SetPageValues(string sortOrder, string searchString, in int pageIndex)
        {
            SortOrder = sortOrder;
            SearchString = searchString;
            PageIndex = pageIndex;
        }

        protected internal async Task GetList(string sortOrder, string currentFilter, string searchString,
            int? pageIndex, string fixedFilter, string fixedValue)
        {

            FixedFilter = fixedFilter;
            FixedValue = fixedValue;
            SortOrder = sortOrder;
            SearchString = GetSearchString(currentFilter, searchString, ref pageIndex);
            PageIndex = pageIndex ?? 1;
            Items = await GetList();
        }

        internal async Task<List<TView>> GetList()
        {
            var l = await db.Get();

            return l.Select(ToView).ToList();
        }

    }
}
