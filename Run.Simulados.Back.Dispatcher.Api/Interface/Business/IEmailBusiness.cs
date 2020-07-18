using Run.Simulados.Back.Dispatcher.Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Run.Simulados.Back.Dispatcher.Api.Interface.Business
{
    public interface IEmailBusiness
    {
        void EmailTreatment(Message message);
    }
}
