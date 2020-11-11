using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using Util.Tests;

namespace Tests {

    public abstract class BaseSealedTests<TClass, TBaseClass> : BaseClassTests<TClass, TBaseClass> {


        [TestMethod] public void IsSealed() {
            Assert.IsTrue(type.IsSealed);
        }


    }

}
