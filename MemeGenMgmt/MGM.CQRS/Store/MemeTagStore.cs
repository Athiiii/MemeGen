using MGM.API.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MGM.CQRS.Store
{
    internal class MemeTagStore
        : IDbMGMStoreCRUD<MemesTag>
    {
        public bool Delete(MemesTag model, int id = -1)
        {
            throw new NotImplementedException();
        }

        public bool Insert(MemesTag model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MemesTag> Select()
        {
            throw new NotImplementedException();
        }

        public MemesTag SelectById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(MemesTag model, int id = -1)
        {
            throw new NotImplementedException();
        }
    }
}
