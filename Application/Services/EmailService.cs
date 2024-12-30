using Application.Interface;
using Application.Utility;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MailKit.Net.Smtp;
//using System.Net.Mail;
//using System.Net;


namespace Application.Services
{
    public class EmailService : IEmailService
    {
        private readonly ApplicationUtil _applicationUtil;
        private readonly IConfiguration _configuration;
        public EmailService(ApplicationUtil applicationUtil,IConfiguration configuration)
        {
            _applicationUtil = applicationUtil;
            _configuration = configuration;

        }
        public async Task SendEmailAsync(string toEmail, string subject, string message)
        {
            if (toEmail != null)
            {
                var emailMessage = new MimeMessage();
                emailMessage.From.Add(new MailboxAddress(_configuration["SmtpSettings:SenderName"], _configuration["SmtpSettings:SenderEmail"]));
                emailMessage.To.Add(new MailboxAddress("", toEmail));
                emailMessage.Subject = subject;
                emailMessage.Body = new TextPart("plain") { Text = message  };
                using (var client = new SmtpClient())
                {

                    await client.ConnectAsync(_configuration["SmtpSettings:Server"], int.Parse(_configuration["SmtpSettings:Port"]), MailKit.Security.SecureSocketOptions.StartTls);
                    await client.AuthenticateAsync(_configuration["SmtpSettings:Username"], _configuration["SmtpSettings:Password"]);
                    await client.SendAsync(emailMessage); await client.DisconnectAsync(true);
                }
            }
        }

    }
}
