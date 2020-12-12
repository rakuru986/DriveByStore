using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;
using Util.Random;

namespace Tests.Services
{
    [TestClass]
    public class UserServiceTests
    {
        private UserService userService;

        [TestInitialize]
        public void TestInitialize()
        {
            userService = new UserService();
        }
        [TestMethod]
        public void verifyUserTest()
        {
            string pw = GetRandom.String();
            string hash = userService.generatePasswordHash(pw);
            Assert.IsTrue(userService.verifyUser(pw, hash));
            string fakepw = GetRandom.String();
            string fakeHash = userService.generatePasswordHash(fakepw);
            Assert.IsFalse(userService.verifyUser(pw, fakeHash));
        }

        [TestMethod]
        public void generatePasswordHashTest()
        {
            var password = GetRandom.String();
            var hash = userService.generatePasswordHash(password);
            Assert.IsTrue(hash.StartsWith("$"));
            Assert.AreEqual(60, hash.Length);
        }
    }
}