using Models.Common;
using Models.Data;
using Models.Data.Orders;

namespace Models.Store
{
    public sealed class OrderDetails : UniqueEntity<OrderDetailsData>
    {
        public OrderDetails() : this(null) { }
        public OrderDetails(OrderDetailsData data) : base(data) { }
    }
}
