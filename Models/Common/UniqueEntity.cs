using Models.Common.Interfaces;
using Models.Data.Common;
using Util;

namespace Models.Common
{
    public abstract class UniqueEntity<T> : Entity<T>, IUniqueEntity<T> where T: UniqueEntityData, new()
    {
        protected internal UniqueEntity(T d = null) : base(d) { }

        public virtual string Id => Data?.Id ?? Constants.Unspecified;
    }
}
