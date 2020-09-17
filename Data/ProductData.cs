using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DriveByStore.Data
{
    public class ProductData
    {
        //[Required]
        //[ScaffoldColumn(false)]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string productId { get; set; }
        
        public string productName { get; set; }
        public double productPrice { get; set; }
        public string productImage { get; set; }
        public double productCategoryId { get; set; }
        public string productCategoryName { get; set; }
        public string productStock { get; set; }
        public string productDescription { get; set; }

    }
}
