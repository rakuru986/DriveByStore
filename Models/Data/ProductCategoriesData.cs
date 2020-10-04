using System.ComponentModel.DataAnnotations.Schema;
using Models.Data.Common;

namespace Models.Data
{
    public class ProductCategoriesData : UniqueEntityData
    {
        public string Name { get; set; }
    }
}