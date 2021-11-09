using AutoMapper;
using Back.Dispatcher.Api.DTO;
using Back.Dispatcher.Api.Enum;
using Back.Dispatcher.Api.Model;
using Back.Dispatcher.Api.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.Dispatcher.Api.AutoMapper
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
