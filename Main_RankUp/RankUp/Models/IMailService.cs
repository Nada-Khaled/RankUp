using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RankUp.Models
{
    public interface IMailService
    {
        public Task SendEmailAsync(MailRequest mailRequest);
        public Task SendWelcomeEmailAsync(WelcomeRequest request);
    }
}
