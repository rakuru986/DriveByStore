using Models.Data.Common;
using Models.Data.Products;

namespace Models.Data.Orders
{
    public class OrderDetailsData : UniqueEntityData
    {
        public string OrderId { get; set; }
        public OrderData Order { get; set; }
        public string ProductId { get; set; }
        public ProductData Product { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}