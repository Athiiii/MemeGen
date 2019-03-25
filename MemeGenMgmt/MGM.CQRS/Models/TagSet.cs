using System;
using System.Collections.Generic;

namespace MGM.CQRS.Models
{
    internal partial class TagSet
    {
        public TagSet()
        {
            MemesTag = new HashSet<MemesTag>();
            TemplateTag = new HashSet<TemplateTag>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<MemesTag> MemesTag { get; set; }
        public virtual ICollection<TemplateTag> TemplateTag { get; set; }
    }
}
