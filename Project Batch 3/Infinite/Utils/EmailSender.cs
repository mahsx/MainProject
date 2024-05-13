namespace dotnershop.Utils
{
    using System.Threading.Tasks;
    using batch3.Utils;

    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Task.CompletedTask;
        }
    }
}