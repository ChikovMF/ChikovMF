namespace ChikovMF.WebApi.Services.EmailService
{
    public interface IEmailSender
    {
        public Task SendEmailAsync(Message message);
    }
}
