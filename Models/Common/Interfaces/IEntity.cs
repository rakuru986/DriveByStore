using System;

namespace Models.Common.Interfaces
{
    public interface IEntity
    {
        DateTime ValidFrom { get; }
        DateTime ValidTo { get; }
        bool IsUnspecified { get; }
    }

    public interface IEntity<out TData> : IEntity
    {
        TData Data { get; }
    }
}
