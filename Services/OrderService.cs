using System;
using System.Globalization;
using System.IO;
using Models.Common;
using Repositories.Interfaces;
using Services.Interfaces;
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

        public async void SendOrderConfirmation(CreateOrderViewModel order, IProductRepository productRepository)
        {
            string filePath = Directory.GetCurrentDirectory() + "\\..\\Util\\EmailTemplates\\OrderConfirmation.html";
            StreamReader str = new StreamReader(filePath);
            string mailText = str.ReadToEnd();
            str.Close();
            mailText = mailText.Replace("[delivery-address]", order.address).Replace("[city]", order.city)
                .Replace("[zip]", order.zip).Replace("[estimated-delivery-date]",
                    DateTime.Today.AddDays(10).ToLongDateString())
                        .Replace("[order-number]", "6969420")
                        .Replace("[total]", order.total.ToString(CultureInfo.CurrentCulture));
            var mail = new MailRequest
            {
                Body = mailText,
                Subject = "Uus tellimus ülilahedalt DriveByStore lehelt",
                ToEmail = order.email
            };
            mailService.SendEmailAsync(mail);
        }
    }
}
