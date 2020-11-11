using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Tests;

namespace Tests
{

    public abstract class AbstractClassTests<TClass, TBaseClass> : BaseClassTests<TClass, TBaseClass>
    {

        [TestMethod]
        public void IsAbstract()
        {
            Assert.IsTrue(type.IsAbstract);
        }

        protected void isAbstractMethod(string name)
        {
            var i = type.GetMethod(name);
            Assert.IsNotNull(i);
            Assert.IsTrue(i.IsAbstract);
        }

        protected void isAbstractProperty(string name)
        {
            var i = type.GetProperty(name);
            Assert.IsNotNull(i);
            if (i.CanRead) Assert.IsTrue(isAbstract(i.GetGetMethod()));
            if (i.CanWrite) Assert.IsTrue(isAbstract(i.GetSetMethod()));
        }
        private static bool isAbstract(MethodInfo i) => i?.IsAbstract ?? false;

    }

}