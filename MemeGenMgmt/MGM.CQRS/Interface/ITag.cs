using System;
using System.Collections.Generic;
using System.Text;
using MGM.CQRS.Models;

namespace MGM.CQRS.Interface
{
    public interface ITag
    {
        bool Delete(Tag model, int id = -1);
        void Insert(Tag model);
        IEnumerable<Tag> Select();
        Tag SelectById(int id);
        bool Update(Tag model, int id = -1);
    }
}
