using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Run.Simulados.Back.Dispatcher.Api.Helpers
{
    public class ConfigEmail
    {
        public string Smtp { get; set; }
        public int PortSmtp { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
    }
}
