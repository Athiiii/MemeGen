using MGM.API.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MGM.CQRS.Store
{
    internal class TemplateTagStore
        : IDbMGMStoreCRUD<TemplateTag>
    {
        public bool Delete(TemplateTag model, int id = -1)
        {
            throw new NotImplementedException();
        }

        public bool Insert(TemplateTag model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TemplateTag> Select()
        {
            throw new NotImplementedException();
        }

        public TemplateTag SelectById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(TemplateTag model, int id = -1)
        {
            throw new NotImplementedException();
        }
    }
}
