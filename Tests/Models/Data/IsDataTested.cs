using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Models.Data
{
    [TestClass]
    public class IsDataTested: AssemblyTests
    {
        protected override string assembly => "Models.Data";

        protected override string nameSpace(string name) { return $"{assembly}.{name}"; }


    }
}
