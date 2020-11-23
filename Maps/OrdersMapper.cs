using System;
using Models.Data;
using Models.Store;
using ViewModels;

namespace Maps
{
    public class OrdersMapper
    {
        public Order mapOrder(CreateOrderViewModel order)
        {

            OrderData orderItem = new OrderData
            {
                ShippingAddress = order.address,
                OrderCity = order.city,
                OrderZip = order.zip,
                OrderPhone = order.phone,
                OrderEmail = order.email,
                OrderShippedTime = DateTime.Now,
                TrackingNumber = new Random().Next(10000000, 99999999).ToString(),
                Total = order.total
            };
            return new Order(orderItem);
        }

        public OrderDetails mapOrderDetails(Product product, OrderProductViewModel fromFront, string orderId)
        {
            OrderDetailsData detailsItem = new OrderDetailsData
            {
                ProductId = product.Id,
                Price = product.Data.Price * fromFront.quantity,
                Quantity = fromFront.quantity,
                OrderId = orderId
            };
            return new OrderDetails(detailsItem);
        }
    }
}
