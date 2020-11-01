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
                 UserId = order.userId,
                 ShippingAddress = order.address,
                 OrderCity = order.city,
                 OrderZip = order.zip,
                 OrderPhone = order.phone,
                 OrderEmail = order.email,
                 OrderShippedTime = order.shippedTime,
                 TrackingNumber = order.trackingNumber,
                 Total = order.total
            };
            return new Order(orderItem);
        }
    }
}
