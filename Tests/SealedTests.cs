using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Tests;

namespace Tests {

    public abstract class SealedTests<TClass, TBaseClass> : ClassTests<TClass, TBaseClass> where TClass : class {


        [TestMethod] public void IsSealed() {
            Assert.IsTrue(type.IsSealed);
        }

    }

}