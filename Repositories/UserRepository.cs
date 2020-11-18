
﻿using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models.Context;

﻿using Models.Context;

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

        public async Task<UserData> getUserByEmail(string email)
        {
            var user = await dbSet.FirstOrDefaultAsync(x => x.Email == email);
            return user;
        }
    }
}
