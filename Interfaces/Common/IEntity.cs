using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.Common
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
