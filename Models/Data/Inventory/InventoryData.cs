using Models.Data.Common;
using Models.Data.Products;

namespace Models.Data.Inventory
{
    public sealed class InventoryData : UniqueEntityData
    {
        public string ProductId { get; set; }
        public ProductData Product { get; set; }
        public int Stock { get; set; }
    }
}
