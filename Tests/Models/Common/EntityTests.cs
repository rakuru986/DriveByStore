using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.Common;
using Models.Common.Interfaces;
using Models.Data.Common;
using Models.Data.Orders;
using Models.Data.Users;
using Models.Store;
using Util.Random;
using Util.Reflection;

namespace Tests.Models.Common
{
    [TestClass]
    public class EntityTests : AbstractClassTests<Entity<UserData>, IEntity<UniqueEntityData>>
    {

        private class testClass : Entity<UserData>
        {

            public testClass(UserData d = null) : base(d) { }

        }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = new testClass();
        }

        [TestMethod] public void DataTest() => isReadOnlyProperty();

        //[TestMethod]
        //public void IsUnspecifiedTest()
        //{
        //    Assert.IsTrue(new testClass().IsUnspecified);
        //    Assert.IsFalse(new testClass(GetRandom.Object<UniqueEntityData>()).IsUnspecified);
        //}

        [TestMethod]
        public void CanSetDataTest()
        {
            var d = GetRandom.Object<UserData>();
            obj = new testClass(d);
            Assert.AreNotSame(d, obj.Data);
            arePropertiesEqual(d, obj.Data);
        }

        [TestMethod]
        public void CanSetNullDataTest()
        {
            obj = new testClass();
            Assert.IsNotNull(obj.Data);
            //Assert.IsTrue(obj.IsUnspecified);
        }

        [TestMethod]
        public void CantChangeDataElementsTest()
        {
            obj = new testClass(GetRandom.Object<UserData>());
            var d = obj.Data;
            obj.Data.Id = GetRandom.String();
            obj.Data.FirstName = GetRandom.String();
            obj.Data.LastName = GetRandom.String();
            obj.Data.PhoneNumber = GetRandom.String();
            obj.Data.Email = GetRandom.Email();
            obj.Data.PasswordHash = GetRandom.Password();
            arePropertiesEqual(d, obj.Data);
        }
    }
}
