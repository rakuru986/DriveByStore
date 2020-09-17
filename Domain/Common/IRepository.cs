﻿namespace DriveByStore.Domain.Common
{
    public interface IRepository<T> : ICrudMethods<T>, IPaging, ISorting, IFiltering
    {
    }
}