using System;

namespace DriveByStore.Data.Common
{
    public abstract class PeriodData : UniqueEntityData
    { 
        public DateTime? Date { get; set; }
    }
}
