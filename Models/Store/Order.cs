using System;
using System.Collections.Generic;
using System.Text;
using Models.Common;
using Models.Data;

namespace Models.Store
{
    public sealed class Order : Entity<OrderData>
    {
        public Order() : this(null) { }
        public Order(OrderData d) : base(d) { }
    }
}
