using System;
using System.ComponentModel.DataAnnotations;

namespace Facade.Common
{
    public abstract class PeriodView : UniqueEntityView
    {
        [DataType(DataType.Date)]
        
        public DateTime? Date { get; set; }
    }
}
