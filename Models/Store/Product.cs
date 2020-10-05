using Models.Common;
using Models.Data;

namespace Models.Store
{
    public sealed class Product : UniqueEntity<ProductData>
    {
        public Product() : this(null) { }

        public Product(ProductData d) : base(d) { }


    }
}
