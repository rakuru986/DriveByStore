namespace ViewModels
{
    public class SaveProductViewModel
    {
        public string name { get; set; }
        public double price { get; set; }
        public string image { get; set; }
        public string categoryId { get; set; }
        public int stock { get; set; }
        public string description { get; set; }
    }

    public class ChangeStockViewModel
    {
        public string mode { get; set; }
        public string productId { get; set; }
        public int changeCount { get; set; }
    }
}
