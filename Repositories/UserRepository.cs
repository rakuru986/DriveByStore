using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models.Context;
using Models.Data;
using Models.Store;
using Models.Store.Interfaces;
using Repositories.Common;

namespace Repositories
{
    public sealed class UserRepository : UniqueEntityRepository<User, UserData>, IUserRepository
    {
        public UserRepository(StoreDbContext c = null) : base(c, c?.Users) { }
        protected internal override User toModelObject(UserData d) => new User(d);

    }
}
