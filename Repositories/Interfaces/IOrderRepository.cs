﻿using Models.Common.Interfaces;
using Models.Store;

namespace Repositories.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        //List<OrderData> getOrdersByUserId(string userId);
    }
}
