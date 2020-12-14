using System.Threading.Tasks;
using Models.Common;

namespace Services.Interfaces
{
    public interface IMailService
    {
        void SendEmail(MailRequest mailRequest);
    }
}
