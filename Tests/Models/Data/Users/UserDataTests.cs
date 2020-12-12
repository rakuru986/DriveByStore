using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.Data.Common;
using Models.Data.Users;

namespace Tests.Models.Data.Users
{
    [TestClass]
    public class UserDataTests : SealedTests<UserData, UniqueEntityData>
    {

        [TestMethod] public void EmailTest() => isNullableProperty<string>();
        [TestMethod] public void FirstNameTest() => isNullableProperty<string>();
        [TestMethod] public void LastNameTest() => isNullableProperty<string>();
        [TestMethod] public void PhoneNumberTest() => isNullableProperty<string>();
        [TestMethod] public void PasswordHashTest() => isProperty<string>();
       


    }
}
