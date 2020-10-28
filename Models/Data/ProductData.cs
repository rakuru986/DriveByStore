using Models.Data.Common;
using Models.Store;

namespace Models.Data
{
    public class ProductData : UniqueEntityData
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public string ProductCategoryId { get; set; }
        public ProductCategoriesData ProductCategory { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }

    }
}
