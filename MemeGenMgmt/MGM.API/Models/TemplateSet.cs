using System;
using System.Collections.Generic;

namespace MGM.API.Models
{
    public partial class TemplateSet
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
