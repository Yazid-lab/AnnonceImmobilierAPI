using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using GestionAnnonce.Application.Common.Interfaces;
using GestionAnnonce.Application.Exceptions;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;

        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task SendEmailAsync(string toEmail, string subject, string body)
        {
            try
            {
                var smtpSettings = _configuration.GetSection("SmtpSettings");

                var smtpServer = smtpSettings["SmtpServer"];
                var smtpUsername = smtpSettings["Username"];
                var smtpPassword = smtpSettings["Password"];

                var smtpClient = new SmtpClient(smtpServer, 587)
                {
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(smtpUsername, smtpPassword)
                };

                return smtpClient.SendMailAsync(new MailMessage(from: smtpUsername ?? string.Empty, to: toEmail, subject, body));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new EmailNotSentException("verification");
            }
        }
    }
}
