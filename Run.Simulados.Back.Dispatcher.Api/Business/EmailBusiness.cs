using Run.Simulados.Back.Dispatcher.Api.Interface.Business;
using Run.Simulados.Back.Dispatcher.Api.Interface.Service;
using Run.Simulados.Back.Dispatcher.Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Run.Simulados.Back.Dispatcher.Api.Business
{
    public class EmailBusiness : IEmailBusiness
    {
        private readonly IEmailBuilderService _emailBuilderService;
        private readonly IEmailSenderService _emailSenderService;

        public EmailBusiness(IEmailSenderService emailSenderService,
                             IEmailBuilderService emailBuilderService)
        {
            _emailBuilderService = emailBuilderService;
            _emailSenderService = emailSenderService;
        }
        public void EmailTreatment(Message message)
        {
            var emails = _emailBuilderService.Build(message);
            foreach (var email in emails)
            {
                _emailSenderService.SendEmail(email);
            }
        }
    }
}
