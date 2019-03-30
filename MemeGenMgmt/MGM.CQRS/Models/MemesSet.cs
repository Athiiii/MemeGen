using System;
using System.Collections.Generic;

namespace MGM.CQRS.Models
{
    public partial class MemesSet
    {
        public MemesSet()
        {
            MemesTag = new HashSet<MemesTag>();
        }

        public int Id { get; set; }
        public string ImagePath { get; set; }
        public string Name { get; set; }
        public string Top { get; set; }
        public string Bottom { get; set; }
        public int FontSize { get; set; }
        public string Watermark { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public int TemplateId { get; set; }
        public int UsersId { get; set; }

        public virtual TemplateSet Template { get; set; }
        public virtual UsersSet Users { get; set; }
        public virtual ICollection<MemesTag> MemesTag { get; set; }
    }
}
