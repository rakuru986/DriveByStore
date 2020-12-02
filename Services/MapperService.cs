using System;
using Models.Data;
using Models.Data.Orders;
using Models.Data.Products;
using Models.Data.Users;
using Models.Store;
using Services.Interfaces;
using ViewModels;

namespace Services
{
    public class MapperService : IMapperService
    {
        public Order mapOrder(CreateOrderViewModel order)
        {
            OrderData orderItem = new OrderData
            {
                ShippingAddress = order.address,
                OrderCity = order.city,
                OrderZip = order.zip,
                OrderPhone = order.phone,
                OrderEmail = order.email,
                OrderShippedTime = DateTime.Now,
                TrackingNumber = new Random().Next(10000000, 99999999).ToString(),
                Total = order.total
            };
            return new Order(orderItem);
        }

        public OrderDetails mapOrderDetails(Product product, OrderProductViewModel fromFront, string orderId)
        {
            OrderDetailsData detailsItem = new OrderDetailsData
            {
                ProductId = product.Id,
                Price = product.Data.Price * fromFront.quantity,
                Quantity = fromFront.quantity,
                OrderId = orderId
            };
            return new OrderDetails(detailsItem);
        }

        public Product mapSaveProduct(SaveProductViewModel product)
        {
            ProductData productItem = new ProductData
            {
                Name = product.name,
                Description = product.description,
                Image = product.image,
                Price = product.price,
                Stock = product.stock,
                ProductCategoryId = product.categoryId
            };
            return new Product(productItem);
        }

        public User mapSaveUser(SaveUserViewModel user, IUserService service)
        {
            string passwordHash = service.generatePasswordHash(user.password);
            var userItem = new UserData
            {
                Email = user.email,
                FirstName = user.firstName,
                LastName = user.lastName,
                PhoneNumber = user.phoneNumber,
                PasswordHash = passwordHash,

            };
            return new User(userItem);
        }
    }
}
