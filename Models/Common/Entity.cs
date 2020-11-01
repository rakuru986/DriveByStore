using Models.Common.Interfaces;
using Models.Data.Common;
using Util;

namespace Models.Common
{
    public abstract class Entity<TData> : IEntity<TData> where TData : UniqueEntityData, new()
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
    }
}
