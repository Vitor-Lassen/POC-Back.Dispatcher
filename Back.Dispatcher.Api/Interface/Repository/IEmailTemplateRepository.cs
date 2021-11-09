using Back.Dispatcher.Api.Enum;
using Back.Dispatcher.Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.Dispatcher.Api.Interface.Repository
{
    public interface IEmailTemplateRepository
    {
        IList<Email> GetEmailTemplate(MessageTypeEnum messageTypeEnum);
    }
}
