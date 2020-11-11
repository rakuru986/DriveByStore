using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{

    public class AssemblyTests : BaseAssemblyTests
    {
        [TestMethod] public void IsCommonTested() => isAllTested(assembly, nameSpace("Common"));
        [TestMethod] public void IsCurrenciesTested() => isAllTested(assembly, nameSpace("Currencies"));
        [TestMethod] public void IsOrdersTested() => isAllTested(assembly, nameSpace("Orders"));
        [TestMethod] public void IsPartiesTested() => isAllTested(assembly, nameSpace("Parties"));
        [TestMethod] public void IsProcessesTested() => isAllTested(assembly, nameSpace("Processes"));
        [TestMethod] public void IsProductsTested() => isAllTested(assembly, nameSpace("Products"));
        [TestMethod] public void IsQuantitiesTested() => isAllTested(assembly, nameSpace("Quantities"));
        [TestMethod] public void IsRolesTested() => isAllTested(assembly, nameSpace("Roles"));
        [TestMethod] public void IsRulesTested() => isAllTested(assembly, nameSpace("Rules"));
    }

}
