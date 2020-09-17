using System.Linq;
using System.Threading.Tasks;
using DriveByStore.Domain.Common;
using Microsoft.AspNetCore.Mvc;

namespace Projekt.Pages
{
    public abstract class CrudPage<TRepository, TDomain, TView, TData> : BasePage<TRepository, TDomain, TView, TData>
        where TRepository : ICrudMethods<TDomain>, ISorting, IFiltering, IPaging
    {
        protected CrudPage(TRepository r) : base(r) { }

        [BindProperty]
        public TView Item { get; set; }

        protected internal async Task<bool> AddObject(string fixedFilter, string fixedValue)
        {
            SetFixedFilter(fixedFilter, fixedValue);

            try
            {
                if (!ModelState.IsValid) return false;
                await db.Add(ToObject(Item));
            }
            catch { return false; }

            return true;
        }

        protected internal async Task<bool> UpdateObject(string fixedFilter, string fixedValue)
        {
            SetFixedFilter(fixedFilter, fixedValue);

            if (!ModelState.IsValid)
            {
	            var errors = ModelState.SelectMany(x =>
		            x.Value.Errors.Select(z => z.Exception));

	            // Breakpoint, Log or examine the list with Exceptions.
            }

            try
            {
	            //var errors = ModelState.Values.SelectMany(v => v.Errors);
                if (!ModelState.IsValid) return false;
                await db.Update(ToObject(Item));
            }
            catch { return false; }

            return true;
        }

        protected internal async Task<bool> UpdateObject(string id, string fixedFilter, string fixedValue)
        {
            SetFixedFilter(fixedFilter, fixedValue);

            try
            {
                if (!ModelState.IsValid) return false;
                await db.Delete(id);
                await db.Add(ToObject(Item));
            }
            catch { return false; }

            return true;
        }

        protected internal async Task GetObject(string id, string fixedFilter, string fixedValue)
        {
            SetFixedFilter(fixedFilter, fixedValue);
            var o = await db.Get(id);
            Item = ToView(o);
        }

        protected internal async Task GetObject(string id, string sortOrder, string searchString, int pageIndex, string fixedFilter, string fixedValue)
        {
            SetPageValues(sortOrder, searchString, pageIndex);
            SetFixedFilter(fixedFilter, fixedValue);
            var o = await db.Get(id);
            Item = ToView(o);
        }

        protected internal async Task DeleteObject(string id, string fixedFilter, string fixedValue)
        {
            SetFixedFilter(fixedFilter, fixedValue);
            await db.Delete(id);
        }

        protected internal abstract TDomain ToObject(TView view);

        protected internal abstract TView ToView(TDomain obj);
    }
}
