﻿//using System.Collections.Generic;
//using System.Threading.Tasks;
//using Models.Common;
//using Models.Data.Common;

//namespace Abc.Tests
//{
//    internal abstract class baseTestRepositoryForPeriodEntity<TObj, TData> 
//        where TObj: Entity<TData>
//    where TData:PeriodData, new()
//    {
//    internal readonly List<TObj> list;
//    public baseTestRepositoryForPeriodEntity()
//    {
//        list = new List<TObj>();
//    }
//    public async Task<List<TObj>> Get()
//    {
//        await Task.CompletedTask;
//        return list;
//    }

//    public async Task<TObj> Get(string id)
//    {
//        await Task.CompletedTask;
//        return list.Find( x => isThis(x, id));
//    }

//    protected abstract bool isThis(TObj entity, string id);

//    public async Task Delete(string id)
//    {
//        await Task.CompletedTask;
//        var obj = list.Find(x => isThis(x, id));
//        list.Remove(obj);

//    }

//    public async Task Add(TObj obj)
//    {
//        await Task.CompletedTask;
//        list.Add(obj);

//    }

//    public async Task Update(TObj obj)
//    {
//        await Delete(getId(obj));
//        list.Add(obj);
//    }

//    protected abstract string getId(TObj entity);

//    public int PageIndex { get; set; }
//    public int PageSize { get; set; }
//    public int TotalPages { get; set; }
//    public bool HasNextPage { get; set; }
//    public bool HasPreviousPage { get; set; }
//    public string SortOrder { get; set; }
//    public string SearchString { get; set; }
//    public string FixedFilter { get; set; }
//    public string FixedValue { get; set; }
//    }
//}
  