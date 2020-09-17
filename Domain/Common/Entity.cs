﻿using Projekt.Data.Common;

namespace Projekt.Domain.Common
{
    public abstract class Entity<TData> where TData: NamedEntityData, new()
    {
        public TData Data { get; internal set; }

        protected internal Entity(TData data = null) => Data = data;
    }
}