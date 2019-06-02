using System;
using System.Collections.Generic;
using System.Text;
using MGM.CQRS.Models;

namespace MGM.CQRS.Interface
{
    public interface IUser
    {
        bool Delete(User model, int id = -1);
        void Insert(User model);
        IEnumerable<User> Select();
        User SelectById(int id);
        bool Update(User model, int id = -1);
        bool UserExists(string username);
        bool MailExists(string mail);
    }
}
