using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Run.Simulados.Back.Dispatcher.Api.DTO;
using Run.Simulados.Back.Dispatcher.Api.Interface.Business;
using Run.Simulados.Back.Dispatcher.Api.Model;

namespace Run.Simulados.Back.Dispatcher.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IEmailBusiness _emailBusiness;
        public EmailController(IEmailBusiness emailBusiness,
                               IMapper mapper)
        {
            _emailBusiness = emailBusiness;
            _mapper = mapper;
        }
        [HttpPost]
        [Route("ContactUs")]
        public IActionResult SendContactUs(ContactUsDTO dto)
        {
            var message = _mapper.Map<MessageParameters>(dto);
            _emailBusiness.EmailTreatment(message);
            return Ok();
        }
        [HttpPost]
        [Route("Send")]
        public IActionResult SendEmail(EmptyEmailDTO dto)
        {
            var message = _mapper.Map<MessageParameters>(dto);
            _emailBusiness.EmailTreatment(message);
            return Ok();
        }
    }
}