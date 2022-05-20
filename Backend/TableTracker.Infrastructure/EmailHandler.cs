using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.Options;

using TableTracker.Domain.DataTransferObjects;
using TableTracker.Domain.Interfaces;
using TableTracker.Domain.Settings;

namespace TableTracker.Infrastructure
{
    public class EmailHandler : IEmailHandler
    {
        private readonly EmailConfig _emailConfig;

        public EmailHandler(IOptions<EmailConfig> emailConfig)
        {
            _emailConfig = emailConfig.Value;
        }

        public async Task SendEmail(EmailDTO email)
        {
            using var mailMessage = new MailMessage
            {
                Sender = new MailAddress(email.From),
                Subject = email.Subject,
                Body = email.Body,
            };

            mailMessage.CC.Add(email.Cc.Aggregate((x, y) => x + "," + y));
            mailMessage.Bcc.Add(email.Bcc.Aggregate((x, y) => x + "," + y));
            mailMessage.To.Add(email.To.Aggregate((x, y) => x + "," + y));

            var smtp = new SmtpClient(_emailConfig.Host, _emailConfig.Port)
            {
                Credentials = new NetworkCredential()
                {
                    UserName = _emailConfig.Address,
                    Password = _emailConfig.Password,
                },

                EnableSsl = true,
            };

            await smtp.SendMailAsync(mailMessage);
        }
    }
}
