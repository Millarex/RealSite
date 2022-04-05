using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System.IO;
using System.Threading.Tasks;

namespace RealSite.Presentation.Services
{
    public class EmailService : IMessageSender
    {
        IWebHostEnvironment _appEnvironment;
        IConfiguration _configuration;
        public EmailService(IWebHostEnvironment appEnvironment, IConfiguration configuration)
        {
            _appEnvironment = appEnvironment;
            _configuration = configuration;
        }
        public async Task SendEmailAsync(string email, string subject, string message, IFormFile uploadedFile = null)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Real Site Administrator", "belikalekseigmail.com@mail.ru"));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            var body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };
            if (uploadedFile != null)
            {
                var attachment = new MimePart("image", "gif")
                {
                    Content = new MimeContent(uploadedFile.OpenReadStream()),
                    ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
                    ContentTransferEncoding = ContentEncoding.Base64,
                    FileName = uploadedFile.FileName
                };
                var multipart = new Multipart("mixed");
                multipart.Add(body);
                multipart.Add(attachment);
                emailMessage.Body = multipart;
            }
            else
                emailMessage.Body = body;

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.mail.ru", 465, true);
                await client.AuthenticateAsync("belikalekseigmail.com@mail.ru", _configuration["SmtpPass:Pass"]);
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }
    }
}
