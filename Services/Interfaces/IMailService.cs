using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Models.Common;

namespace Services.Interfaces
{
    public interface IMailService
    {
        void SendEmailAsync(MailRequest mailRequest);
    }
}
