using System.Threading.Tasks;
using Maps;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.Data;
using Models.Data.Users;
using Models.Store.Interfaces;
using ViewModels;

namespace Soft.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository orderRepository;
        private readonly UserManager<UserData> userManager;

        public OrderController(IOrderRepository o, UserManager<UserData> um)
        {
            orderRepository = o;
            userManager = um;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderViewModel order)
        {
            if (order == null) return Json(BadRequest());
            var mapper = new OrdersMapper();
            var orderItem = mapper.mapOrder(order);
            await orderRepository.Add(orderItem);
            return Json(Ok(orderItem));
        }

        [HttpPost]
        public IActionResult GetUserOrders([FromBody] UserOrderViewModel user)
        {
            //if (user == null) return Json(BadRequest());
            //var activeUser = userManager.GetUserAsync(HttpContext.User);
            //var u = HttpContext.User.Identity.Name;
            //var orders = orderRepository.getOrdersByUserId(user.userId);
            return Json(Ok());
        }
    }
}
