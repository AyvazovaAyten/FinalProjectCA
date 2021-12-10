using MailKit.Net.Smtp;
using MimeKit;
using SushiStore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SushiStore.Services
{
    public class EmailService : IMail
    {
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("BakeRoll", "230420asdfx@gmail.com"));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                client.CheckCertificateRevocation = false;

                await client.ConnectAsync("smtp.gmail.com", 465, true);
                await client.AuthenticateAsync("230420asdfx@gmail.com", "bakeRoll582");
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }
    }
}
