using System;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using Models.Common;
using Repositories.Interfaces;
using Services.Interfaces;
using Util;
using ViewModels;

namespace Services
{
    public class OrderService : IOrderService
    {
        private readonly IMailService mailService;

        public OrderService(IMailService ms)
        {
            mailService = ms;
        }

        public async Task SendOrderConfirmation(CreateOrderViewModel order, IProductRepository productRepository, string orderId)
        {
            string filePath = Directory.GetCurrentDirectory() + "\\..\\Util\\EmailTemplates\\OrderConfirmation.html";
            StreamReader str = new StreamReader(filePath);
            string mailText = str.ReadToEnd();
            str.Close();

            var allProductsHtml = "";
            foreach (var product in order.productList)
            {
                var productData = await productRepository.Get(product.productId);
                var productHtml = Constants.OrderConfirmationEmailProductHtml
                    .Replace("[product-name]", productData.Data.Name)
                    .Replace("[product-price]", (productData.Data.Price * product.quantity).ToString(CultureInfo.CurrentCulture))
                    .Replace("[product-quantity]", product.quantity.ToString());
                allProductsHtml += productHtml;
            }

            mailText = mailText.Replace("[products-html]", allProductsHtml)
                .Replace("[delivery-address]", order.address)
                .Replace("[city]", order.city)
                .Replace("[zip]", order.zip)
                .Replace("[estimated-delivery-date]", DateTime.Today.AddDays(10).ToLongDateString())
                .Replace("[order-number]", orderId.Substring(0, 8))
                .Replace("[total]", order.total.ToString(CultureInfo.CurrentCulture));
            var mail = new MailRequest
            {
                Body = mailText,
                Subject = Constants.OrderConfirmationEmailSubject,
                ToEmail = order.email
            };
            await mailService.SendEmail(mail);
        }
    }
}
