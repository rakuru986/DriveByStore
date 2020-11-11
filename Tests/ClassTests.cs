using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Random;

namespace Tests {

    public abstract class ClassTests<TClass, TBaseClass> : BaseClassTests<TClass, TBaseClass> where TClass : class {


        [TestInitialize] public override void TestInitialize() {
            obj = createObject();
            type = obj.GetType();
        }
        protected virtual TClass createObject() => GetRandom.Object<TClass>();

    }

}