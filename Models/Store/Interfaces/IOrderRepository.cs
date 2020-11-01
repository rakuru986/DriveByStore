using System.Collections.Generic;
using Models.Common.Interfaces;
using Models.Data;

namespace Models.Store.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        List<OrderData> getOrdersByUserId(string userId);
    }
}
