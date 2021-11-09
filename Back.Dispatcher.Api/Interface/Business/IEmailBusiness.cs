using Back.Dispatcher.Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.Dispatcher.Api.Interface.Business
{
    public interface IEmailBusiness
    {
        void EmailTreatment(Message message);
    }
}
