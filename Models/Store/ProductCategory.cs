using Models.Common;
using Models.Data;

namespace Models.Store
{
    public sealed class ProductCategory : UniqueEntity<ProductCategoriesData>
    {
        public ProductCategory() : this(null) { }
        public ProductCategory(ProductCategoriesData data) : base(data) { }
    }
}
