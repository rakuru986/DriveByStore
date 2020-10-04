using System;
using System.Collections.Generic;
using System.Text;
using Models.Common;
using Models.Data;

namespace Models.Store
{
    public sealed class OrderDetails : Entity<OrderDetailsData>
    {
        public OrderDetails() : this(null) { }
        public OrderDetails(OrderDetailsData data) : base(data) { }
    }
}
