﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using Run.Simulados.Back.Dispatcher.Api.Model;
using Run.Simulados.Back.Dispatcher.Api.Helpers;
using Microsoft.Extensions.Options;
using Run.Simulados.Back.Dispatcher.Api.Interface;

namespace Run.Simulados.Back.Dispatcher.Api.Service
{
    public class EmailService : IEmailService
    {
        private readonly ConfigEmail _emailConfig;

        public EmailService(IOptions<ConfigEmail> emailconfig)
        {
            _emailConfig = emailconfig.Value;
        }
        public void SendEmail(Email email)
        {
            MailMessage mail = new MailMessage()
            {
                From = new MailAddress(_emailConfig.Email, _emailConfig.Name),
                To = { new MailAddress(email.Address) },
                Subject = email.Subject,
                Body = email.Body,
                IsBodyHtml = true,
                Priority = MailPriority.Normal,
            };


            using SmtpClient smtp = new SmtpClient(_emailConfig.Smtp, _emailConfig.PortSmtp)
            {
                Credentials = new NetworkCredential(_emailConfig.Email, _emailConfig.Password),
                EnableSsl = true
            };
            smtp.Send(mail);

        }
    }
}
