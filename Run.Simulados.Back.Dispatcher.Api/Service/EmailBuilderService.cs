using Microsoft.Extensions.Configuration;
using Run.Simulados.Back.Dispatcher.Api.Interface.Repository;
using Run.Simulados.Back.Dispatcher.Api.Interface.Service;
using Run.Simulados.Back.Dispatcher.Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Run.Simulados.Back.Dispatcher.Api.Service
{
    public class EmailBuilderService : IEmailBuilderService
    {
        private readonly IEmailTemplateRepository _emailTemplateRepository;
        private readonly string _supportEmail;
        public EmailBuilderService(IEmailTemplateRepository emailTemplateRepository, 
                                   IConfiguration configuration)
        {
            _emailTemplateRepository = emailTemplateRepository;
            _supportEmail = configuration.GetSection("SupportEmail").Value;
        }
        public IList<Email> Build(Message message)
        {
            var templates = _emailTemplateRepository.GetEmailTemplate(message.Type);
            switch (message) {
                case MessageParameters mp:
                    foreach (var template in templates)
                    {
                        BuildTemplateMessage(template, mp);
                    }
                break;
                default:
                    throw new NotImplementedException();
            }
            return templates;
        }
        private void  BuildTemplateMessage(Email email, MessageParameters messageParameters)
        {
            email.Subject = ReplaceParameters(email.Subject, messageParameters.Parameters);
            email.Body = ReplaceParameters(email.Body, messageParameters.Parameters);
            if (email.ToClient)
                email.Address = messageParameters.Email;
            else
                email.Address = _supportEmail;
        }
        private string ReplaceParameters(string template, IDictionary<string,string> parameters)
        {
            foreach (var param in parameters)
            {
                if (!template.Contains("{{"))
                    break;
                template = template.Replace("{{" + param.Key + "}}", param.Value);
            }
            return template;
        }
    }
}
