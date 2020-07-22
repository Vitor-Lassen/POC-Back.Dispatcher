using AutoMapper;
using Run.Simulados.Back.Dispatcher.Api.DTO;
using Run.Simulados.Back.Dispatcher.Api.Enum;
using Run.Simulados.Back.Dispatcher.Api.Model;
using Run.Simulados.Back.Dispatcher.Api.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Run.Simulados.Back.Dispatcher.Api.AutoMapper
{
    public class MessageAutoMapper : Profile
    {
        public MessageAutoMapper()
        {
            CreateMap<ContactUsDTO, MessageParameters>()
                .ForMember(d => d.Parameters, o => o.MapFrom(s => s.ToDictionary()))
                .BeforeMap((s, d) => d.Type = MessageTypeEnum.ContactUs);

            CreateMap<EmptyEmailDTO, MessageParameters>()
               .ForMember(d => d.Parameters, o => o.MapFrom(s => s.ToDictionary()))
               .BeforeMap((s, d) => d.Type = MessageTypeEnum.Empty);
        }
    }
}
