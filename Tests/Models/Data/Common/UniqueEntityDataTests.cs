using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.Data;
using Models.Data.Common;
using Models.Store;
using Repositories.Common;

namespace Tests.Models.Data.Common {

    [TestClass] public class UniqueEntityDataTests : AbstractClassTests<UniqueEntityData,object> {

        private class testClass : UniqueEntityData { }

        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            obj = new testClass();
        }

        [TestMethod] public void IdTest()
            => isNullableProperty(() => obj.Id, x => obj.Id = x);

    }

}