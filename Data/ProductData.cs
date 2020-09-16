using System;

namespace Data
{
    public abstract class ProductData
    {
        public double productId { get; set; }
        public string productName { get; set; }
        public string productPrice { get; set; }
        public string productImage { get; set; }
        public double productCategoryId { get; set; }
        public string productCategoryName { get; set; }
        public string productStock { get; set; }

    }
}
