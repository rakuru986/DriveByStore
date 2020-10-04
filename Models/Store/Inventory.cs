using System;
using System.Collections.Generic;
using System.Text;
using Models.Common;
using Models.Data;

namespace Models.Store
{
    public sealed class Inventory : Entity<InventoryData>
    {
        public Inventory() : this(null) { }
        public Inventory(InventoryData data) : base(data) { }
    }
}
