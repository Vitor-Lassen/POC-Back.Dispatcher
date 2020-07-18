using Run.Simulados.Back.Dispatcher.Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Run.Simulados.Back.Dispatcher.Api.Interface.Service
{
    public interface IEmailBuilderService
    {
        IList<Email> Build(Message message);
    }
}
