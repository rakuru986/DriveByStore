using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.Context;
using Models.Data.Users;
using Models.Store;
using Repositories.Common;
using Repositories.Users;

namespace Tests.Repositories.Users
{
    [TestClass]
    public class
        UserRepositoryTests : UserRepositoriesTests<UserRepository, User, UserData>
    {

        protected override Type getBaseClass() => typeof(UniqueEntityRepository<User, UserData>);

        protected override UserRepository getObject(StoreDbContext c) => new UserRepository(c);

        protected override DbSet<UserData> getSet(StoreDbContext c) => c.Users;

    }
}
