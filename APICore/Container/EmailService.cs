using APICore.Modal;
using APICore.Service;

using Microsoft.Extensions.Options;
using MimeKit;
using System.Net.Mail;

namespace APICore.Container
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings emailSettings;
        public EmailService(IOptions<EmailSettings> options)
        {
            this.emailSettings = options.Value;
        }
        public async Task SendEmail(Mailrequest mailrequest, string @string)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(emailSettings.Email);
            email.To.Add(MailboxAddress.Parse(mailrequest.Email));
            email.Subject = mailrequest.Subject;
            var builder = new BodyBuilder();
            builder.HtmlBody = mailrequest.Emailbody;
            email.Body = builder.ToMessageBody();

            using var smtp = new SmtpClient();
        
        }

        public async Task SendEmail(Mailrequest mailrequest)
        {
            throw new NotImplementedException();
        }
    }
}
