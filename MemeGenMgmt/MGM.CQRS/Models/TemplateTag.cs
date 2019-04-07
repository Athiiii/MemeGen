﻿using System;
using System.Collections.Generic;

namespace MGM.CQRS.Models
{
    public partial class Templatetag
    {
        public int TemplateId { get; set; }
        public int TagId { get; set; }

        public virtual Tag Tag { get; set; }
        public virtual Template Template { get; set; }
    }
}
