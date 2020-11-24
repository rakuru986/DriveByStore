using Models.Context;
using Models.Data;
using Models.Store;
using Repositories.Common;
using Repositories.Interfaces;

namespace Repositories
{
    public sealed class InventoryRepository : UniqueEntityRepository<Inventory, InventoryData>, IInventoryRepository
    {
        public InventoryRepository(StoreDbContext c) : base(c, c?.Inventory) { }
        protected internal override Inventory toModelObject(InventoryData d) => new Inventory();
    }
}
