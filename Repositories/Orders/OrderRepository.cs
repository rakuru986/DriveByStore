using System.Collections.Generic;
using System.Linq;
using Models.Context;
using Models.Data.Orders;
using Models.Store;
using Repositories.Common;
using Repositories.Interfaces;

namespace Repositories.Orders
{
    public sealed class OrderRepository : UniqueEntityRepository<Order, OrderData>, IOrderRepository
    {
        public OrderRepository(StoreDbContext c = null) : base(c, c?.Orders) { }
        protected internal override Order toModelObject(OrderData d) => new Order(d);

        public List<OrderData> getOrdersByUserId(string id)
        {
            var orders = dbSet.Where(x => x.UserId == id).ToList();
            return orders;
        }
    }
}
