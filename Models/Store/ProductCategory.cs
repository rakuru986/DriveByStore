using System;
using System.Collections.Generic;
using System.Text;
using Models.Common;
using Models.Data;

namespace Models.Store
{
    public sealed class ProductCategory : Entity<ProductCategoriesData>
    {
        public ProductCategory() : this(null) { }
        public ProductCategory(ProductCategoriesData data) : base(data) { }
    }
}
