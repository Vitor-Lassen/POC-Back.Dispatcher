using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.Dispatcher.Api.Model
{
    public class MessageParameters : Message
    {
        public IDictionary<string,string> Parameters { get; set; }
    }
}
