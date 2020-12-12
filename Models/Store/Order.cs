using Models.Common;
using Models.Data.Orders;

namespace Models.Store
{
    public sealed class Order : UniqueEntity<OrderData>
    {
        public Order() : this(null) { }
        public Order(OrderData d) : base(d) { }
    }
}
