using Models.Common;
using Models.Data;

namespace Models.Store
{
    public sealed class User : UniqueEntity<UserData>
    {
        public User() : this(null) { }
        public User(UserData d) : base(d) { }
    }
}
