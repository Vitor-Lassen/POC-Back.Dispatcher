﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Run.Simulados.Back.Dispatcher.Api.Model
{
    public class Email
    {
        public bool ToClient { get; set; }
        public string Address { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

    }
}
