using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Projekt.Facade.Common
{
    public abstract class PeriodView : UniqueEntityView
    {
        [DataType(DataType.Date)]
        
        public DateTime? Date { get; set; }
    }
}
