using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.Context;
using Models.Data;
using Models.Store;
using Models.Store.Interfaces;
using Repositories;
using Repositories.Common;
using Tests.Repositories.Common;
using Tests.Repositories.Products;

namespace Tests.Repositories.Users
{
    [TestClass]
    public class
        InventoryRepositoryTests : InventoryRepositoriesTests<InventoryRepository, Inventory, InventoryData>
    {

        protected override Type getBaseClass() => typeof(UniqueEntityRepository<Inventory, InventoryData>);

        protected override InventoryRepository getObject(StoreDbContext c) => new InventoryRepository(c);

        protected override DbSet<InventoryData> getSet(StoreDbContext c) => c.Inventory;

    }
}
