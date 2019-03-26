using System;
using System.Collections.Generic;

namespace MGM.API.Models
{
    public partial class MemesTag
    {
        public int MemesId { get; set; }
        public int TagId { get; set; }

        public virtual MemesSet Memes { get; set; }
        public virtual TagSet Tag { get; set; }
    }
}
