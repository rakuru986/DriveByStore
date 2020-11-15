using System;
using System.Collections.Generic;
using System.Net.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.Common.Interfaces;
using Models.Data.Common;
using Soft;
using Tests.Soft;
using Util;
using Util.Random;

namespace Tests {

    public abstract class BaseSoftTests : BaseTests {

        protected static readonly TestHost<Startup> host;
        protected static readonly HttpClient client;

        static BaseSoftTests() {
            host = new TestHost<Startup>();
            client = host.CreateClient();
        }

        protected void getFromRepository<TData, TObject, TRepository>(string id, Func<TData> getData,
            Func<TData, TObject> toObject)

            where TData : UniqueEntityData, new()
            where TObject : IUniqueEntity<TData>
            where TRepository : IRepository<TObject> {
            var d = GetRandom.Object<TData>();
            GetRepository.Instance<TRepository>().Add(toObject(d)).GetAwaiter();
            Assert.IsNotNull(getData());
            arePropertiesEqual(getData(), new TData(), "Id");
            d.Id = id;
            GetRepository.Instance<TRepository>().Add(toObject(d)).GetAwaiter();
            arePropertiesEqual(d, getData());
        }

        protected void getFromRepository<TData, TObject, TRepository>(
            TData d, Func<TData> getData, Func<TData, TObject> toObject)

            where TData : UniqueEntityData, new()
            where TObject : IEntity<TData>
            where TRepository : IRepository<TObject> {
            GetRepository.Instance<TRepository>().Add(toObject(d)).GetAwaiter();
            arePropertiesEqual(d, getData());
        }

        protected void getListFromRepository<TDetail, TData, TRepository>(
            object obj, string name, Action<TData> setId, Func<TData, TDetail> toObject)

            where TRepository : IRepository<TDetail> {

            var t = isReadOnlyProperty(obj, name) as IReadOnlyList<TDetail>;
            Assert.IsNotNull(t);
            Assert.AreEqual(0, t.Count);
            var values = GetRepository.Instance<TRepository>();
            var valuesCount = GetRandom.UInt8(10, 20);

            for (var i = 0; i < valuesCount; i++) {
                var d = GetRandom.Object<TData>();
                if (i % 4 == 0) setId(d);
                values.Add(toObject(d)).GetAwaiter();
            }

            t = isReadOnlyProperty(obj, name) as IReadOnlyList<TDetail>;
            Assert.AreEqual((int) Math.Ceiling(valuesCount / 4.0), t?.Count);
        }

        protected static void isReadOnlyProperty(object o, string name, object expected) {
            var actual = isReadOnlyProperty(o, name);
            Assert.AreEqual(expected, actual);
        }

        protected static object isReadOnlyProperty(object o, string name) {
            var property = o.GetType().GetProperty(name);
            Assert.IsNotNull(property);
            Assert.IsFalse(property.CanWrite);
            Assert.IsTrue(property.CanRead);

            return property.GetValue(o);
        }

    }

}
