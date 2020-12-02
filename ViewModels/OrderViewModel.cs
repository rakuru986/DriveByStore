using System.Collections.Generic;

namespace ViewModels
{
    public class CreateOrderViewModel
    {
        public string address { get; set; }
        public string city { get; set; }
        public string zip { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public double total { get; set; }
        public List<OrderProductViewModel> productList { get; set; }
    }

    public class OrderProductViewModel
    {
        public string productId { get; set; }
        public int quantity { get; set; }
    }

    public class UserOrderViewModel
    {
        public string userId { get; set; }
    }
}
