using Models.Context;
using Models.Data;
using Models.Store;
using Models.Store.Interfaces;
using Repositories.Common;

namespace Repositories
{
    public sealed class OrderRepository : UniqueEntityRepository<Order, OrderData>, IOrderRepository
    {
        public OrderRepository(StoreDbContext c = null) : base(c, c?.Orders) { }
        protected internal override Order toModelObject(OrderData d) => new Order(d); 
    }
}
