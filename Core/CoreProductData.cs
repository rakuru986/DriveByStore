using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    public class CoreProductData
    {
        public CoreProductData(string productId, string productName, double productPrice, string productImage, double productCategoryId, string productCategoryName, string productStock, string productDescription)
        {
            ProductId = productId;
            ProductName = productName;
            ProductPrice = productPrice;
            ProductImage = productImage;
            ProductCategoryId = productCategoryId;
            ProductCategoryName = productCategoryName;
            ProductStock = productStock;
            ProductDescription = productDescription;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ProductId;
        public string ProductName;
        public double ProductPrice;
        public string ProductImage;
        public double ProductCategoryId;
        public string ProductCategoryName;
        public string ProductStock;
        public string ProductDescription;
    }
}
