using Back.Dispatcher.Api.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.Dispatcher.Api.Model
{
    public class Message
    {
        public MessageTypeEnum Type{ get; set; }
        public string Email { get; set; }
        
    }
}
