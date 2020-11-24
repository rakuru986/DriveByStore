using Models.Common;
using Models.Data;
using Models.Data.Inventory;

namespace Models.Store
{
    public sealed class Inventory : UniqueEntity<InventoryData>
    {
        public Inventory() : this(null) { }
        public Inventory(InventoryData data) : base(data) { }
    }
}
