using System.Threading.Tasks;
using Maps;
using Microsoft.AspNetCore.Mvc;
using Repositories.Interfaces;
using ViewModels;

namespace Soft.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository orderRepository;
        private readonly IOrderDetailsRepository orderDetailsRepository;
        private readonly IProductRepository productRepository;
        private readonly OrdersMapper mapper;

        public OrderController(IOrderRepository o, IOrderDetailsRepository od, IProductRepository p)
        {
            orderRepository = o;
            orderDetailsRepository = od;
            productRepository = p;
            mapper = new OrdersMapper();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderViewModel order)
        {
            if (order == null) return Json(BadRequest());
            var orderItem = mapper.mapOrder(order);
            string orderId = orderItem.Id;
            await orderRepository.Add(orderItem);
            foreach (var product in order.productList)
            {
                var productItem = await productRepository.Get(product.productId);
                var detailsItem = mapper.mapOrderDetails(productItem, product, orderId);
                await orderDetailsRepository.Add(detailsItem);
            }
            return Json(Ok(orderItem));
        }

        //[HttpPost]
        //public IActionResult GetUserOrders([FromBody] UserOrderViewModel user)
        //{
        //    if (user == null) return Json(BadRequest());
        //    var activeUser = userManager.GetUserAsync(HttpContext.User);
        //    var u = HttpContext.User.Identity.Name;
        //    var orders = orderRepository.getOrdersByUserId(user.userId);
        //    return Json(Ok());
        //}
    }
}
