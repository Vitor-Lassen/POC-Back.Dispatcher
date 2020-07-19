using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Run.Simulados.Back.Dispatcher.Api.DTO;
using Run.Simulados.Back.Dispatcher.Api.Model;

namespace Run.Simulados.Back.Dispatcher.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IMapper _mapper;
        public EmailController(IMapper mapper)
        {
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult SendEmail(ContactUsDTO dto)
        {
            var result = _mapper.Map<MessageParameters>(dto);
            return Ok();
        }
    }
}