using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.Common
{
    public interface IRepository<T> : ICrudMethods<T>
    {

    }

    public interface IRepository
    {
        object getById(string id);
    }
}
