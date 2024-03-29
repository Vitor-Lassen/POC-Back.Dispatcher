﻿using Back.Dispatcher.Api.Enum;
using Back.Dispatcher.Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.Dispatcher.Api.Helpers
{
    public class TemplateEmailConfig
    {
        public MessageTypeEnum MessageType { get; set; }
        public IList<Email> Emails { get; set; }
    }
}
