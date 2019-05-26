using System;
using System.Collections.Generic;
using System.Text;
using MGM.CQRS.Models;

namespace MGM.CQRS.Interface
{
    public interface IMemeTag
    {
        bool Delete(Memetag model, int tagId = -1, int modelId = -1);
        void Insert(Memetag model);
        IEnumerable<Memetag> Select();
        IEnumerable<Memetag> SelectById(int tagId, int valueId);
        bool Update(Memetag model);
    }
}
