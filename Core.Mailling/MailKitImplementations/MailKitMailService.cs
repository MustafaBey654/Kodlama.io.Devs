using Microsoft.Extensions.Configuration;
using MimeKit;
using System;  
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using MailKit.Net.Smtp;
using MimeKit;

namespace Core.Mailling.MailKitImplementations
{
    public class MailKitMailService : IMailService
    {

        private IConfiguration _configuration;
        private readonly MailSettings _mailSettings;


        public void SendMail(Mail mail)
        {
            MimeMessage email = new MimeMessage();
            email.From.Add(new MailboxAddress(_mailSettings.SenderFullName, _mailSettings.SenderEmail));
            email.To.Add(new MailboxAddress(mail.ToFullName,mail.ToEmail));

            email.Subject = mail.Subject;

            BodyBuilder bodyBuilder = new()
            {
                TextBody = mail.TextBody,
                HtmlBody = mail.HtmlBody
            };

            if(mail.Attachments != null) 
                foreach (MimeEntity? attachment in mail.Attachments)
                    bodyBuilder.Attachments.Add(attachment);

            email.Body = bodyBuilder.ToMessageBody();

            using MailKit.Net.Smtp.SmtpClient smtp = new();
            //smtp.Authenticate(_mailSettings.UserName,_mailSettings.Password);
            smtp.Send(email);
            smtp.Disconnect(true);

        }
    }
}
