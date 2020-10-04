using System;
using System.Collections.Generic;
using System.Text;
using Interfaces.Common;
using Models.Data.Common;
using Util;

namespace Models.Common
{
    public abstract class Entity<TData> : BaseEntity, IEntity<TData> where TData : PeriodData, new()
    {
        protected readonly TData data;
        protected internal Entity(TData d = null) => data = d;

        public TData Data
        {
            get
            {
                if (data is null) return null;
                var d = new TData();
                Copy.Members(data, d);

                return d;
            }
        }

        public virtual DateTime ValidFrom => Data?.ValidFrom ?? DateTime.MinValue;
        public virtual DateTime ValidTo => Data?.ValidTo ?? DateTime.MaxValue;

        public bool IsUnspecified => data is null;
    }
}
