using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.Common;
using Models.Data.Users;
using Models.Store;

namespace Tests.Models.Store
{
    [TestClass] public class UserTests : SealedTests<User, UniqueEntity<UserData>> { }
}
