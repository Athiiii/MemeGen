using System;
using System.Collections.Generic;
using System.Text;
using MGM.CQRS.Models;

namespace MGM.CQRS.Interface
{
    public interface IMeme
    {
        bool Delete(Meme model, int id = -1);
        void Insert(Meme model);
        IEnumerable<Meme> Select();
        IEnumerable<Meme> SelectByUser(int userId);
        bool Update(Meme model, int id = -1);
    }
}
