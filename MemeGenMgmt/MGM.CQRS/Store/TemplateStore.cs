﻿using MGM.API.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MGM.CQRS.Store
{
    internal class TemplateStore
        : IDbMGMStoreCRUD<TemplateSet>
    {
        public bool Delete(TemplateSet model, int id = -1)
        {
            throw new NotImplementedException();
        }

        public bool Insert(TemplateSet model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TemplateSet> Select()
        {
            throw new NotImplementedException();
        }

        public TemplateSet SelectById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(TemplateSet model, int id = -1)
        {
            throw new NotImplementedException();
        }
    }
}
