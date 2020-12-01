using System.Threading.Tasks;
using Models.Common;

namespace Services.Interfaces
{
    public interface IMailService
    {
        Task SendEmail(MailRequest mailRequest);
    }
}
