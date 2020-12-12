using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.Common.Interfaces;
using Util;
using Util.Random;
using Util.Reflection;


namespace Tests {

    public abstract class BaseClassTests<TClass, TBaseClass> : BaseSoftTests {

        protected TClass obj;

        [TestInitialize] public virtual void TestInitialize() => type = typeof(TClass);

        [TestCleanup] public virtual void TestCleanup() {
            type = null;
            obj = default;
        }

        [TestMethod] public void IsInheritedTest()
            => Assert.AreEqual(getBaseClass(), type.BaseType);

        [TestMethod] public void CanCreateTest() => Assert.IsNotNull(obj);


        protected virtual Type getBaseClass() => typeof(TBaseClass);

        protected static void isNullableProperty<T>(Func<T> get, Action<T> set) {
            isProperty(get, set);
            set(default);
            Assert.IsNull(get());
        }

        protected static void isProperty<T>(Func<T> get, Action<T> set) {
            var d = (T) GetRandom.Value(typeof(T));

            while (true) {
                if (!d.Equals(get())) break;
                d = (T) GetRandom.Value(typeof(T));
            }

            Assert.AreNotEqual(d, get());
            set(d);
            Assert.AreEqual(d, get());
        }

        protected static void isProperty(Func<bool> get, Action<bool> set) {
            var d = !get();
            Assert.AreNotEqual(d, get());
            set(d);
            Assert.AreEqual(d, get());
        }

        protected static void isNullableProperty(object o, string name, Type t) {
            isProperty(o, name, t);
            var p = o.GetType().GetProperty(name);
            canSetValue(o, p, null);
        }

        protected static void isProperty(object o, string name, Type t) {
            var p = isReadWriteProperty(o, name, t);
            canSetValue(o, p, GetRandom.Value(t));
        }
        private static void canSetValue(object o, PropertyInfo p, object v) {
            p.SetValue(o, v);
            Assert.AreEqual(v, p.GetValue(o));
        }
        protected static PropertyInfo isReadWriteProperty(object o, string name, Type t) {
            var p = o.GetType().GetProperty(name);
            Assert.IsNotNull(p);
            Assert.AreEqual(t, p.PropertyType);
            Assert.IsTrue(p.CanWrite);
            Assert.IsTrue(p.CanRead);

            return p;
        }
        protected static void hasDisplayName(string propertyName, string displayName)
            => Assert.AreEqual(displayName, GetMember.DisplayName<TClass>(propertyName));

        protected void isProperty<TType>(string propertyName, string displayName) {
            isProperty(obj, propertyName, typeof(TType));
            hasDisplayName(propertyName, displayName);
        }

        protected void isNullableProperty<TType>(string propertyName, string displayName) {
            isNullableProperty(obj, propertyName, typeof(TType));
            hasDisplayName(propertyName, displayName);
        }

        protected void isProperty<TType>() {
            var n = getPropertyName();
            isProperty(obj, n, typeof(TType));
        }

        protected string getPropertyName(int stackFrameIdx = 2) {
            var stack = new StackTrace();
            var n = stack.GetFrame(stackFrameIdx)?.GetMethod()?.Name;

            return n?.Replace("Test", string.Empty);
        }
        
        protected void isNullableProperty<TType>() {
            var n = getPropertyName();
            isNullableProperty(obj, n, typeof(TType));
        }

        protected void isProperty<TType>(string displayName) {
            var n = getPropertyName();
            isProperty(obj, n, typeof(TType));
            hasDisplayName(n, displayName);
        }

        protected void isNullableProperty<TType>(string displayName) {
            var n = getPropertyName();
            isNullableProperty(obj, n, typeof(TType));
            hasDisplayName(n, displayName);
        }

        protected void isReadOnlyProperty(object expected) {
            var n = getPropertyNameAfter("isReadOnlyProperty");
            isReadOnlyProperty(obj, n, expected);
        }
        
        protected void isReadOnlyProperty() {
            var n = getPropertyNameAfter("isReadOnlyProperty");
            isReadOnlyProperty(obj, n);
        }
        
        protected void getListFromRepository<TDetail, TData, TRepository>(
            Action<TData> setId, Func<TData, TDetail> toObject) where TRepository : IRepository<TDetail> {
            var n = getPropertyNameAfter("getListFromRepository");
            getListFromRepository<TDetail, TData, TRepository>(obj, n, setId, toObject);
        }

        protected string getPropertyNameAfter(string methodName) {
            var stack = new StackTrace();
            int i;
            for ( i = 0; i < stack.FrameCount - 1; i++) {
                var n = stack.GetFrame(i)?.GetMethod()?.Name;

                if (n == methodName) break;
            }

            for (i += 1; i < stack.FrameCount - 1; i++)
            {
                var n = stack.GetFrame(i)?.GetMethod()?.Name;

                if (n == "MoveNext" || n == "Start") continue;

                return n?.Replace("Test", string.Empty);
            }

            return string.Empty;
        }

        protected void testRelatedList<TObject, TData, TRelatedObject, TRepository>(
            Func<IReadOnlyList<TObject>> getList,
            Func<IReadOnlyList<TRelatedObject>> getRelatedList,
            Func<TData, TRelatedObject, TObject> getObject,
            Action relatedMethod)
            where TRepository : IRepository<TObject> {
            var n = getPropertyNameAfter("testRelatedList");
            isReadOnlyProperty(obj, n);
            Assert.AreEqual(0, getList().Count);
            relatedMethod();

            foreach (var e in getRelatedList()) {
                var d = GetRandom.Object<TData>();
                GetRepository.Instance<TRepository>().Add(getObject(d, e)).GetAwaiter();
            }

            Assert.AreNotEqual(0, getList().Count);
            Assert.AreEqual(getRelatedList().Count, getList().Count);
        }

    }

}