using MGM.API.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MGM.CQRS.Store
{
    internal class UserStore
        : IDbMGMStoreCRUD<UsersSet>
    {
        public bool Delete(UsersSet model, int id = -1)
        {
            throw new NotImplementedException();
        }

        public bool Insert(UsersSet model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UsersSet> Select()
        {
            throw new NotImplementedException();
        }

        public UsersSet SelectById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(UsersSet model, int id = -1)
        {
            throw new NotImplementedException();
        }
    }
}
