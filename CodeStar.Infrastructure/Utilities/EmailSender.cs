using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CodeStar.Infrastructure.Utilities
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string to, string subject, string body);
    }

    public class GmailEmailSender : IEmailSender
    {
        private readonly string _from = "MortezaAkbaridp@gmail.com"; // آدرس جیمیل خودت
        private readonly string _appPassword = "hmhy jbta nsna qiqh"; // رمز ۱۶ رقمی که ساختی

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            using var client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(_from, _appPassword),
                EnableSsl = true
            };

            var mail = new MailMessage(_from, to, subject, body)
            {
                IsBodyHtml = true
            };

            await client.SendMailAsync(mail);
        }
    }
}
