﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.Dispatcher.Api.Model
{
    public class Email
    {
        public string Address { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

    }
}
