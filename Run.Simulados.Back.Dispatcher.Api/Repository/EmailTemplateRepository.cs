using Run.Simulados.Back.Dispatcher.Api.Enum;
using Run.Simulados.Back.Dispatcher.Api.Interface.Repository;
using Run.Simulados.Back.Dispatcher.Api.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Run.Simulados.Back.Dispatcher.Api.Repository
{
    public class EmailTemplateRepository : IEmailTemplateRepository
    {
        public IList<Email> GetEmailTemplate(MessageTypeEnum messageTypeEnum)
        {
            return GetEmailTemplateContactUs();
        }
        private IList<Email> GetEmailTemplateContactUs()
        {
            return new List<Email>()
            {
                new Email()
                {
                    ToClient = true,
                    Subject = "Agradecemos seu contato",
                    Body = GetEmailTemplateByName("ContactUSToClient")
                },
                new Email()
                {
                    ToClient = false,
                    Subject = "Novo contato de {{Name}} {{LastName}}",
                    Body = GetEmailTemplateByName("ContactUSToSupport")
                }
            };
        }
        private string GetEmailTemplateByName(string templateName)
        {
            FileStream fileStream = new FileStream($"Repository/Templates/{templateName}.html", FileMode.Open);
            using (StreamReader reader = new StreamReader(fileStream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
