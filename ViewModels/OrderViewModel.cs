using System;

namespace ViewModels
{
    public class CreateOrderViewModel
    {
        public string userId { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string zip { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public DateTime shippedTime { get; set; }
        public string trackingNumber { get; set; }
        public double total { get; set; }
    }

    public class UserOrderViewModel
    {
        public string userId { get; set; }
    }
}
