using System;

namespace Data
{
    public class OrderData
    {
        public double orderId { get; set; }
        public double orderUserId { get; set; }
        public string orderShipAddress { get; set; }
        public string orderCity { get; set; }
        public string orderZip { get; set; }
        public string orderPhone { get; set; }
        public string orderEmail { get; set; }
        public DateTime orderShipped { get; set; }
        public string orderTrackingNumber { get; set; }
        public double orderTotal { get; set; }

    }
}