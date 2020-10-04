using System.ComponentModel.DataAnnotations.Schema;
using Models.Data.Common;

namespace Models.Data
{
    public class InventoryData : UniqueEntityData
    {
        public int ProductId { get; set; }
        public int Stock { get; set; }
    }
}
