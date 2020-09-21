using System;

namespace DriveByStore.Data
{
    public class OrderData
    {
        public double Id { get; set; }
        public double UserId { get; set; }
        public string ShippingAddress { get; set; }
        public string OrderCity { get; set; }
        public string OrderZip { get; set; }
        public string OrderPhone { get; set; }
        public string OrderEmail { get; set; }
        public DateTime OrderShippedTime { get; set; }
        public string TrackingNumber { get; set; }
        public double Total { get; set; }
    }
}