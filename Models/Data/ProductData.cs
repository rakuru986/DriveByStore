using Models.Data.Common;

namespace Models.Data
{
    public class ProductData : UniqueEntityData
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public string ProductCategoryId { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }

    }
}
