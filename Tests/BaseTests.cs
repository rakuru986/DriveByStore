using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Classes;
using Util.Reflection;

namespace Tests {

    public class BaseTests {

        private const string notTested = "<{0}> is not tested";
        private const string notSpecified = "Class is not specified";
        private List<string> members { get; set; }
        protected Type type;
        protected string typeName => getName();

        private string getName() {
            var s = type.Name;
            var index = s.IndexOf("`", StringComparison.Ordinal);
            if (index > -1) s = s.Substring(0, index);

            return s;
        }

        [TestMethod] public virtual void IsTested() {
            if (type == null) Assert.Inconclusive(notSpecified);
            var m = GetClass.Members(type, PublicFlagsFor.Declared);
            members = m.Select(e => e.Name).ToList();
            removeTested();

            if (members.Count == 0) return;
            Assert.Inconclusive(notTested, members[0]);
        }

        [TestMethod] public virtual void IsSpecifiedClassTested() {
            if (type == null) Assert.Inconclusive(notSpecified);
            var className = GetType().Name;
            Assert.IsTrue(className.StartsWith(typeName));
        }

        private void removeTested() {
            var tests = GetType().GetMembers().Select(e => e.Name).ToList();

            for (var i = members.Count; i > 0; i--) {
                var m = members[i - 1] + "Test";
                var isTested = tests.Find(o => o == m);

                if (string.IsNullOrEmpty(isTested)) continue;
                members.RemoveAt(i - 1);
            }
        }

        protected static void arePropertiesEqual(object obj1, object obj2, params string[] except) {
            foreach (var property in obj1.GetType().GetProperties()) {
                var name = property.Name;

                if (except.Contains(name)) continue;
                var p = obj2.GetType().GetProperty(name);
                Assert.IsNotNull(p, $"No property with name '{name}' found.");
                var expected = property.GetValue(obj1);
                var actual = p.GetValue(obj2);
                Assert.AreEqual(expected, actual, $"For property'{name}'.");
            }
        }

        protected static void arePropertiesNotEqual(object obj1, object obj2) {
            foreach (var property in obj1.GetType().GetProperties()) {
                var name = property.Name;
                var p = obj2.GetType().GetProperty(name);
                Assert.IsNotNull(p, $"No property with name '{name}' found.");
                var expected = property.GetValue(obj1);
                var actual = p.GetValue(obj2);

                if (expected != actual) return;
            }

            Assert.Fail("All properties are same");
        }
        protected internal static void removeAll<TData>(DbSet<TData> set, DbContext db) where TData : class, new() {
            if (set is null) return;
            if (db is null) return;

            foreach (var i in set) {
                try {
                    set.Remove(i);
                    db.SaveChanges();
                } catch (Exception e) {
                    Assert.Fail($"{typeof(TData).Name}:{e.Message}");
                }

            }

            Assert.AreEqual(0, set.Count(), typeof(TData).Name);
        }

        protected string solutionDir { get {
                var dirName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                var lenght = dirName.IndexOf("Abc") + 3;
                dirName = dirName.Substring(0, lenght);
                return dirName;
            }


        }
    }

}