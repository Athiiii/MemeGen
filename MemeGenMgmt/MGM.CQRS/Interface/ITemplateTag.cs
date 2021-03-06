﻿using System;
using System.Collections.Generic;
using System.Text;
using MGM.CQRS.Models;

namespace MGM.CQRS.Interface
{
    public interface ITemplateTag
    {
        bool Delete(Templatetag model, int tagId = -1, int modelId = -1);
        void Insert(Templatetag model);
        IEnumerable<Templatetag> Select();
        IEnumerable<Templatetag> SelectById(int tagId, int valueId);
        bool Update(Templatetag model, int id = -1);
    }
}
