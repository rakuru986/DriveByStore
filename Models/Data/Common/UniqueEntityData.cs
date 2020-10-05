using System;

namespace Models.Data.Common
{
    public abstract class UniqueEntityData : PeriodData
    {

        public string Id { get; set; } = Guid.NewGuid().ToString();
    }
}
