using Models.Common;
using Models.Data;

namespace Models.Store
{
    public sealed class OrderDetails : UniqueEntity<OrderDetailsData>
    {
        public OrderDetails() : this(null) { }
        public OrderDetails(OrderDetailsData data) : base(data) { }
    }
}
