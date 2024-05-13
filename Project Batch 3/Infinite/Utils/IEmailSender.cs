namespace batch3.Utils
{
    using System.Threading.Tasks;

    public interface IEmailSender
    {

        Task SendEmailAsync(string email, string subject, string htmlMessage);
    }
}
