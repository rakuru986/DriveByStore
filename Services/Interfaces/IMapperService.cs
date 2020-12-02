using Models.Store;
using ViewModels;

namespace Services.Interfaces
{
    public interface IMapperService
    {
        Order mapOrder(CreateOrderViewModel order);
        OrderDetails mapOrderDetails(Product product, OrderProductViewModel fromFront, string orderId);
        Product mapSaveProduct(SaveProductViewModel product);
        User mapSaveUser(SaveUserViewModel user, IUserService service);
    }
}
