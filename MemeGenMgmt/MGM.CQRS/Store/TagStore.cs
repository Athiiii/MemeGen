using MGM.API.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MGM.CQRS.Store
{
    internal class TagStore
        : IDbMGMStoreCRUD<TagSet>
    {
        public bool Delete(TagSet model, int id = -1)
        {
            throw new NotImplementedException();
        }

        public bool Insert(TagSet model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TagSet> Select()
        {
            throw new NotImplementedException();
        }

        public TagSet SelectById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(TagSet model, int id = -1)
        {
            throw new NotImplementedException();
        }
    }
}
