using System.Collections.Generic;
using Models.Common.Interfaces;
using Models.Data;
using Models.Data.Orders;
using Models.Store;

namespace Repositories.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        List<OrderData> getOrdersByUserId(string userId);
    }
}
