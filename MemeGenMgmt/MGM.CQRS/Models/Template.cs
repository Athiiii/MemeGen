using System;
using System.Collections.Generic;

namespace MGM.CQRS.Models
{
    public partial class Template
    {
        public Template()
        {
            Meme = new HashSet<Meme>();
            Templatetag = new HashSet<Templatetag>();
        }

        public int Id { get; set; }
        public string ImagePath { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Meme> Meme { get; set; }
        public virtual ICollection<Templatetag> Templatetag { get; set; }
    }
}
