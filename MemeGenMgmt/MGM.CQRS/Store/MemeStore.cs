using MGM.API.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MGM.CQRS.Store
{
    internal class MemeStore : IDbMGMStoreCRUD<MemesSet>
    {
        public bool Delete(MemesSet model, int id = -1)
        {
            throw new NotImplementedException();
        }

        public bool Insert(MemesSet model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MemesSet> Select()
        {
            throw new NotImplementedException();
        }

        public MemesSet SelectById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(MemesSet model, int id = -1)
        {
            throw new NotImplementedException();
        }
    }
}
