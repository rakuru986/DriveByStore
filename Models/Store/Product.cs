using System;
using System.Collections.Generic;
using System.Text;
using Models.Common;
using Models.Data;

namespace Models.Store
{
    public sealed class Product : Entity<ProductData>
    {
        public Product() : this(null) { }

        public Product(ProductData d) : base(d) { }


    }
}
