using System;
using System.Collections.Generic;

namespace MGM.CQRS.Models
{
    internal partial class TemplateSet
    {
        public TemplateSet()
        {
            MemesSet = new HashSet<MemesSet>();
            TemplateTag = new HashSet<TemplateTag>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }

        public virtual ICollection<MemesSet> MemesSet { get; set; }
        public virtual ICollection<TemplateTag> TemplateTag { get; set; }
    }
}
