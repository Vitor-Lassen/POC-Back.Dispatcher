using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Run.Simulados.Back.Dispatcher.Api.AutoMapper
{
    public class AutoMapperConfig
    {
        public static IMapper Configure()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MessageAutoMapper());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            return mapper;
        }
    }
}
