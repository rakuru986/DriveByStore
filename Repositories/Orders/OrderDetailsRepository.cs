using Models.Context;
using Models.Data.Orders;
using Models.Store;
using Repositories.Common;
using Repositories.Interfaces;

namespace Repositories.Orders
{
    public sealed class OrderDetailsRepository : UniqueEntityRepository<OrderDetails, OrderDetailsData>, IOrderDetailsRepository
    {
        public OrderDetailsRepository(StoreDbContext c = null) : base(c, c?.OrderDetails) { }
        protected internal override OrderDetails toModelObject(OrderDetailsData d) => new OrderDetails(d);
    }
}
