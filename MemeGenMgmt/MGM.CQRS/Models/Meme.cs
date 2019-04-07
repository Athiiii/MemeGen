using System;
using System.Collections.Generic;

namespace MGM.CQRS.Models
{
    public partial class Meme
    {
        public Meme()
        {
            Memetag = new HashSet<Memetag>();
        }

        public int Id { get; set; }
        public string ImagePath { get; set; }
        public string Name { get; set; }
        public string Top { get; set; }
        public string Bottom { get; set; }
        public int? FontSize { get; set; }
        public string Watermark { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public int UserId { get; set; }
        public int? TemplateId { get; set; }

        public virtual Template Template { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Memetag> Memetag { get; set; }
    }
}
