using Microsoft.Extensions.Options;
using Back.Dispatcher.Api.Enum;
using Back.Dispatcher.Api.Helpers;
using Back.Dispatcher.Api.Interface.Repository;
using Back.Dispatcher.Api.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Back.Dispatcher.Api.Repository
{
    public class EmailTemplateRepository : IEmailTemplateRepository
    {
        private readonly List<TemplateEmailConfig> _templateEmailConfig;
        public EmailTemplateRepository(IOptions<List<TemplateEmailConfig>> templateEmailConfig)
        {
            _templateEmailConfig = templateEmailConfig.Value;
        }
        public IList<Email> GetEmailTemplate(MessageTypeEnum messageTypeEnum)
        {
            var templates = _templateEmailConfig.Find(s => s.MessageType == messageTypeEnum);
            foreach (var email in templates.Emails)
            {
                email.Body = GetEmailTemplateByName(email.Body);
            }
            return templates.Emails;
        }

        private string GetEmailTemplateByName(string templateName)
        {
            FileStream fileStream = new FileStream($"Repository/Templates/{templateName}", FileMode.Open);
            using (StreamReader reader = new StreamReader(fileStream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
