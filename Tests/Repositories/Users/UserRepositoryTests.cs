using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.Context;
using Models.Data;
using Models.Data.Users;
using Models.Store;
using Models.Store.Interfaces;
using Repositories;
using Repositories.Common;
using Repositories.Users;
using Tests.Repositories.Common;
using Tests.Repositories.Products;

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
