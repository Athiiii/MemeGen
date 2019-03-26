using System;
using System.Collections.Generic;

namespace MGM.API.Models
{
    public partial class TemplateTag
    {
        public int TemplateId { get; set; }
        public int TagId { get; set; }

        public virtual TagSet Tag { get; set; }
        public virtual TemplateSet Template { get; set; }
    }
}
