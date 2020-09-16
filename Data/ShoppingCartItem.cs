namespace Data
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }
        public ProductData Product { get; set; }
        public int Amount { get; set; }
        public string CartId { get; set; }
    }
}