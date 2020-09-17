namespace DriveByStore.Data
{
    public class ShoppingCartItemData
    {
        public int shoppingCartItemId { get; set; }
        public ProductData product { get; set; }
        public int amount { get; set; }
        public string cartId { get; set; }
    }
}