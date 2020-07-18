using Run.Simulados.Back.Dispatcher.Api.Enum;
using Run.Simulados.Back.Dispatcher.Api.Interface.Repository;
using Run.Simulados.Back.Dispatcher.Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Run.Simulados.Back.Dispatcher.Api.Repository
{
    public class EmailTemplateRepository : IEmailTemplateRepository
    {
        public IList<Email> GetEmailTemplate(MessageTypeEnum messageTypeEnum) 
        {
            throw new NotImplementedException();
        }
        private IList<Email> GetEmailTemplateContactUs()
        {
            return new List<Email>()
            {
                new Email()
            };
        }
    }
}
