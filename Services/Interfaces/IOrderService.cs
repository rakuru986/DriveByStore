using System;
using System.Collections.Generic;
using System.Text;
using Models.Common;
using Repositories.Interfaces;
using ViewModels;

namespace Services.Interfaces
{
    public interface IOrderService
    {
        void SendOrderConfirmation(CreateOrderViewModel order, IProductRepository productRepository);
    }
}
