using Models.Context;
using Models.Data;
using Models.Data.Inventory;
using Models.Store.Interfaces;
using Repositories.Common;
using Repositories.Interfaces;

namespace Repositories.Inventory
{
    public sealed class InventoryRepository : UniqueEntityRepository<Models.Store.Inventory, InventoryData>, IInventoryRepository
    {
        public InventoryRepository(StoreDbContext c) : base(c, c?.Inventory) { }
        protected internal override Models.Store.Inventory toModelObject(InventoryData d) => new Models.Store.Inventory(d);
    }
}
