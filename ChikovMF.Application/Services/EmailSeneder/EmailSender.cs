using MailKit.Net.Smtp;
using MimeKit;

namespace ChikovMF.WebApi.Services.EmailService
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailConfiguration _conf;

        public EmailSender(EmailConfiguration configuration)
        {
            _conf = configuration;
        }

        public async Task SendEmailAsync(Message message)
        {
            MimeMessage emailMessage = CreateEmailMessage(message);

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(_conf.SmtpServer, _conf.Port, true);
                await client.AuthenticateAsync(_conf.From, _conf.Password);

                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }

        private MimeMessage CreateEmailMessage(Message message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress(_conf.UserName, _conf.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message.Content
            };
            return emailMessage;
        }
    }
}
