using System;
using Models.Data.Common;
using Models.Data.Users;

namespace Models.Data.Orders
{
    public sealed class OrderData : UniqueEntityData
    {
        public string UserId { get; set; }
        public UserData User { get; set; }
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