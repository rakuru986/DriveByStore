using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Services
{
    [TestClass]
    public class AreServicesTested : AssemblyTests
    {
        protected override string assembly => "Services";

        protected override string nameSpace(string name) => assembly;
    }
}
