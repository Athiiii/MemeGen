using System;
using System.Collections.Generic;
using System.Linq;
using MGM.API.Models;

namespace MGM.CQRS.Store
{
    internal class UserStore
        : IDbMgmStoreCrud<UsersSet>
    {
        public bool Delete(UsersSet model, int id = -1)
        {
            using (var context = new MGMContext())
            {
                if (id != -1)
                {
                    var user = context.UsersSet.FirstOrDefault(x => x.Id == id);
                    if (user == null) return false;
                    {
                        context.UsersSet.Remove(user);
                        context.SaveChanges();
                        return context.UsersSet.FirstOrDefault(x => x.Id == id) == null;
                    }
                }
                context.Attach(model);
                context.UsersSet.Remove(model);
                context.SaveChanges();
                return context.UsersSet.FirstOrDefault(x => x.Id == model.Id) == null;
            }
        }

        public void Insert(UsersSet model)
        {
            using (var context = new MGMContext())
            {
                context.UsersSet.Add(model);
                context.SaveChangesAsync();
            }
        }

        public IEnumerable<UsersSet> Select()
        {
            using (var context = new MGMContext())
                return context.UsersSet;
        }

        public UsersSet SelectById(int id)
        {
            using (var context = new MGMContext())
                return context.UsersSet.FirstOrDefault(x => x.Id == id);
        }

        public bool Update(UsersSet model, int id = -1)
        {
            using (var context = new MGMContext())
            {
                var user = id != -1 ? context.UsersSet.FirstOrDefault(x => x.Id == id) : context.UsersSet.FirstOrDefault(x => x.Id == model.Id);
                if (user == null)
                    return false;


                context.SaveChangesAsync();

                user.Mail = model.Mail;
                user.Password = model.Password;
                user.Username = model.Username;
               
                return true;
            }
        }
    }
}
