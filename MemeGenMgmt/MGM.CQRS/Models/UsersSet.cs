using System;
using System.Collections.Generic;

namespace MGM.CQRS.Models
{
    internal partial class UsersSet
    {
        public UsersSet()
        {
            MemesSet = new HashSet<MemesSet>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }

        public virtual ICollection<MemesSet> MemesSet { get; set; }
    }
}
