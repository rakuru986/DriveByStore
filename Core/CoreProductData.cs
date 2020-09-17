using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    public class CoreProductData
    {
        public CoreProductData(double productId, string productName, double productPrice, string productImage, double productCategoryId, string productCategoryName, string productStock)
        {
            ProductId = productId;
            ProductName = productName;
            ProductPrice = productPrice;
            ProductImage = productImage;
            ProductCategoryId = productCategoryId;
            ProductCategoryName = productCategoryName;
            ProductStock = productStock;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public double ProductId;
        public string ProductName;
        public double ProductPrice;
        public string ProductImage;
        public double ProductCategoryId;
        public string ProductCategoryName;
        public string ProductStock;
    }
}
