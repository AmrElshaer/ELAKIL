using ELAKIL.Business.Common.Models;
using ELAKIL.Business.IService;
using ELAKIL.UI.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELAKIL.UI
{
    public class MailService:IMailService
    {
        private readonly IOptions<MailSettings> _mailSettings;

        public MailService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings;
        }

        public async Task SendAsync(MessageModel message)
        {

            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_mailSettings.Value.Mail);
            email.To.Add(MailboxAddress.Parse(message.To));
            email.Subject = message.Subject;
            var builder = new BodyBuilder();
            builder.HtmlBody = message.Body;
            email.Body = builder.ToMessageBody();
            using (var smtp = new SmtpClient())
            {
                smtp.Connect(_mailSettings.Value.Host, _mailSettings.Value.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(_mailSettings.Value.Mail, _mailSettings.Value.Password);
                await smtp.SendAsync(email);
                smtp.Disconnect(true);
            }


        }
    }
}
