using System.Threading.Tasks;
using Repositories.Interfaces;
using ViewModels;

namespace Services.Interfaces
{
    public interface IOrderService
    {
        Task SendOrderConfirmation(CreateOrderViewModel order, IProductRepository productRepository, string orderId);
    }
}
