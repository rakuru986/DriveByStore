using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.Data.Products;
using Models.Store;
using Services;
using Util.Random;
using ViewModels;

namespace Tests.Services
{
    [TestClass]
    public class MapperServiceTests
    {
        private MapperService mapperService;
        private UserService userService;

        [TestInitialize]
        public void TestInitialize()
        {
            mapperService = new MapperService();
            userService = new UserService();
        }

        [TestMethod]
        public void mapOrderTest()
        {
            var viewmodel = GetRandom.Object<CreateOrderViewModel>();
            var mappedOrder = mapperService.mapOrder(viewmodel);

            Assert.AreEqual(typeof(Order), mappedOrder.GetType());
            Assert.AreEqual(viewmodel.email, mappedOrder.Data.OrderEmail);
            Assert.AreEqual(viewmodel.address, mappedOrder.Data.ShippingAddress);
            Assert.AreEqual(viewmodel.city, mappedOrder.Data.OrderCity);
            Assert.AreEqual(viewmodel.phone, mappedOrder.Data.OrderPhone);
            Assert.AreEqual(viewmodel.total, mappedOrder.Data.Total);
            Assert.AreEqual(viewmodel.zip, mappedOrder.Data.OrderZip);
        }

        [TestMethod]
        public void mapOrderDetailsTest()
        {
            var productData = GetRandom.Object<ProductData>();
            var product = new Product(productData);
            var productvm = GetRandom.Object<OrderProductViewModel>();
            var orderId = GetRandom.String();
            var mappedDetails = mapperService.mapOrderDetails(product, productvm, orderId);

            Assert.AreEqual(typeof(OrderDetails), mappedDetails.GetType());
            Assert.AreEqual(product.Id, mappedDetails.Data.ProductId);
            Assert.AreEqual(productvm.quantity*product.Data.Price, mappedDetails.Data.Price);
            Assert.AreEqual(productvm.quantity, mappedDetails.Data.Quantity);
            Assert.AreEqual(orderId, mappedDetails.Data.OrderId);
        }

        [TestMethod]
        public void mapSaveProductTest()
        {
            var saveProduct = GetRandom.Object<SaveProductViewModel>();
            var mappedProduct = mapperService.mapSaveProduct(saveProduct);

            Assert.AreEqual(typeof(Product), mappedProduct.GetType());
            Assert.AreEqual(saveProduct.name, mappedProduct.Data.Name);
            Assert.AreEqual(saveProduct.stock, mappedProduct.Data.Stock);
            Assert.AreEqual(saveProduct.price, mappedProduct.Data.Price);
            Assert.AreEqual(saveProduct.categoryId, mappedProduct.Data.ProductCategoryId);
            Assert.AreEqual(saveProduct.description, mappedProduct.Data.Description);
            Assert.AreEqual(saveProduct.image, mappedProduct.Data.Image);
        }

        [TestMethod]
        public void mapSaveUserTest()
        {
            var uservm = GetRandom.Object<SaveUserViewModel>();
            var mappedUser = mapperService.mapSaveUser(uservm, userService);

            Assert.AreEqual(typeof(User), mappedUser.GetType());
            Assert.AreEqual(uservm.email, mappedUser.Data.Email);
            Assert.AreEqual(uservm.firstName, mappedUser.Data.FirstName);
            Assert.AreEqual(uservm.lastName, mappedUser.Data.LastName);
            Assert.IsTrue(userService.verifyUser(uservm.password, mappedUser.Data.PasswordHash));
            Assert.AreEqual(uservm.phoneNumber, mappedUser.Data.PhoneNumber);
        }
    }
}