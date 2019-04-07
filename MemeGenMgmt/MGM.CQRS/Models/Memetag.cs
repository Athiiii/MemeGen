using System;
using System.Collections.Generic;

namespace MGM.CQRS.Models
{
    public partial class Memetag
    {
        public int MemeId { get; set; }
        public int TagId { get; set; }

        public virtual Meme Meme { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
