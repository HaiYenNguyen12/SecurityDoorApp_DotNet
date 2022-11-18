using MailKit;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit.Text;
using MimeKit;
using Security_Door_App.Data.Models;
using MailKit.Net.Smtp;

namespace Security_Door_App.API.Services
{
    public class EmailService : IEmail
    {
        
        public async Task<bool> SendEmailAsync(string toEmail, string confirmLink)
        {
            // create email message
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("girlmilk123@gmail.com"));
            email.To.Add(MailboxAddress.Parse(toEmail));
            email.Subject = "Confirm EMail";
            email.Body = new TextPart(TextFormat.Plain) { Text = confirmLink };

            // send email
            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("girlmilk123@gmail.com", "nlxqkuqkgtmerqog");
            var res = smtp.Send(email);
            smtp.Disconnect(true);
            return true;
        }
    }
}
