using System;
using System.Collections.Generic;

namespace MGM.CQRS.Models
{
    public partial class User
    {
        public User()
        {
            Meme = new HashSet<Meme>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Meme> Meme { get; set; }
    }
}
