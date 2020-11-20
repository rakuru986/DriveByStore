using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.Common;
using Models.Data;
using Util.Random;

namespace Tests.Models
{

    [TestClass]
    public class UniqueEntityTests : AbstractClassTests<UniqueEntity<UserData>, Entity<UserData>>
    {

        private class testClass : UniqueEntity<UserData>
        {

            public testClass(UserData d = null) : base(d) { }

        }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = new testClass(GetRandom.Object<UserData>());
        }

        [TestMethod] public void IdTest() => isReadOnlyProperty(obj.Id);

    }

}
