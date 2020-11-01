using System;

namespace Models.Data.Common
{
    public abstract class UniqueEntityData
    {

        public string Id { get; set; } = Guid.NewGuid().ToString();
    }
}
