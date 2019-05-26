using MGM.CQRS.Models;
using System.Collections.Generic;
using System.Linq;

namespace MGM.CQRS.Store
{
    public class UserStore
        : IDbMgmStoreCrud<User>
    {
        public bool Delete(User model, int id = -1)
        {
            using (var context = new MGMContext())
            {
                if (id != -1)
                {
                    var user = context.User.FirstOrDefault(x => x.Id == id);
                    if (user == null) return false;
                    {
                        context.User.Remove(user);
                        context.SaveChanges();
                        return context.User.FirstOrDefault(x => x.Id == id) == null;
                    }
                }
                context.Attach(model);
                context.User.Remove(model);
                context.SaveChanges();
                return context.User.FirstOrDefault(x => x.Id == model.Id) == null;
            }
        }

        public void Insert(User model)
        {
            using (var context = new MGMContext())
            {
                context.User.Add(model);
                context.SaveChanges();
            }
        }

        public IEnumerable<User> Select()
        {
            using (var context = new MGMContext())
                return context.User.ToList();
        }

        public User SelectById(int id)
        {
            using (var context = new MGMContext())
                return context.User.FirstOrDefault(x => x.Id == id);
        }

        public bool Update(User model, int id = -1)
        {
            using (var context = new MGMContext())
            {
                var user = id != -1 ? context.User.FirstOrDefault(x => x.Id == id) : context.User.FirstOrDefault(x => x.Id == model.Id);
                if (user == null)
                    return false;

                user.Mail = model.Mail;
                user.Password = model.Password;
                user.Username = model.Username;

                context.SaveChanges();

                return true;
            }
        }
    }
}
