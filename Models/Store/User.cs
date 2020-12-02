using Models.Common;
using Models.Data;
using Models.Data.Users;

namespace Models.Store
{
    public sealed class User : UniqueEntity<UserData>
    {
        public User() : this(null) { }
        public User(UserData d) : base(d) { }
    }
}
