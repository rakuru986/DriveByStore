using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Models.Common.Interfaces;
using Models.Data;

namespace Models.Store.Interfaces
{
    public interface IProductCategoryRepository : IRepository<ProductCategory>
    {
    }
}
