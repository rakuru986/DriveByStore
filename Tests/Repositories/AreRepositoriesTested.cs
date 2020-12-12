using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Repositories
{
    [TestClass] public class AreRepositoriesTested : AssemblyTests
    {
        protected override string assembly => "Repositories";

        protected override string nameSpace(string name) => $"{assembly}.{name}";
    }
}
