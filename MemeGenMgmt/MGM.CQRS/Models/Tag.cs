using System;
using System.Collections.Generic;

namespace MGM.CQRS.Models
{
    public partial class Tag
    {
        public Tag()
        {
            Memetag = new HashSet<Memetag>();
            Templatetag = new HashSet<Templatetag>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Memetag> Memetag { get; set; }
        public virtual ICollection<Templatetag> Templatetag { get; set; }
    }
}
