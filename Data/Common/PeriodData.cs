using System;

namespace Projekt.Data.Common
{
    public abstract class PeriodData : UniqueEntityData
    { 
        public DateTime? Date { get; set; }
    }
}
