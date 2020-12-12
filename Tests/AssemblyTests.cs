using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{

    public class AssemblyTests : BaseAssemblyTests
    {
        [TestMethod] public void IsCommonTested() => isAllTested(assembly, nameSpace("Common"));
        [TestMethod] public void IsOrdersTested() => isAllTested(assembly, nameSpace("Orders"));
        [TestMethod] public void IsProductsTested() => isAllTested(assembly, nameSpace("Products"));
        [TestMethod] public void IsUsersTested() => isAllTested(assembly, nameSpace("Users"));
        
    }

}
