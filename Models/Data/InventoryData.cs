using Models.Data.Common;

namespace Models.Data
{
    public class InventoryData : UniqueEntityData
    {
        public string ProductId { get; set; }
        public ProductData Product { get; set; }
        public int Stock { get; set; }
    }
}
