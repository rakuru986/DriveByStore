using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.Context;
using Models.Data;
using Models.Data.Inventory;
using Repositories.Common;
using Repositories.Inventory;

namespace Tests.Repositories.Inventory
{
    [TestClass]
    public class
        InventoryRepositoryTests : InventoryRepositoriesTests<InventoryRepository, global::Models.Store.Inventory, InventoryData>
    {

        protected override Type getBaseClass() => typeof(UniqueEntityRepository<global::Models.Store.Inventory, InventoryData>);

        protected override InventoryRepository getObject(StoreDbContext c) => new InventoryRepository(c);

        protected override DbSet<InventoryData> getSet(StoreDbContext c) => c.Inventory;

    }
}
