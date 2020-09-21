using System.IO;
using System.Threading.Tasks;
using CNX.Configs.Email;
using CNX.Contracts.DTO;
using CNX.Contracts.Interfaces;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;

namespace CNX.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailConfiguration _emailConfiguration;
        public EmailService(IOptions<EmailConfiguration> emailConfiguration)
        {
            _emailConfiguration = emailConfiguration.Value;
        }

        public async Task SendEmailAsync(MailRequestDto mailRequest)
        {
            var email = new MimeMessage {Sender = MailboxAddress.Parse(_emailConfiguration.Mail)};

            email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
            email.Subject = mailRequest.Subject;
            
            var builder = new BodyBuilder {HtmlBody = mailRequest.Body};

            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            
            await smtp.ConnectAsync(_emailConfiguration.Host, _emailConfiguration.Port, SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(_emailConfiguration.Mail, _emailConfiguration.Password);
            
            await smtp.SendAsync(email);
            
            await smtp.DisconnectAsync(true);
        }
    }
}
