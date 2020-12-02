using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.Data;
using Models.Data.Common;
using Models.Data.Orders;
using Models.Data.Users;

namespace Tests.Models.Data.Orders {

    [TestClass]
    public class OrderDataTests : SealedTests<OrderData, UniqueEntityData>
    {
        [TestMethod] public void UserIdTest() => isNullableProperty<string>();
        [TestMethod] public void UserTest() => isProperty<UserData>();
        [TestMethod] public void ShippingAddressTest() => isNullableProperty<string>();
        [TestMethod] public void OrderCityTest() => isNullableProperty<string>();
        [TestMethod] public void OrderZipTest() => isNullableProperty<string>();
        [TestMethod] public void OrderPhoneTest() => isNullableProperty<string>();
        [TestMethod] public void OrderEmailTest() => isNullableProperty<string>();
        [TestMethod] public void OrderShippedTimeTest() => isProperty<DateTime>();
        [TestMethod] public void TrackingNumberTest() => isNullableProperty<string>();
        [TestMethod] public void TotalTest() => isProperty<double>();

    }

}
