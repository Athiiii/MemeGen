using System;
using System.Collections.Generic;
using System.Text;

namespace MGM.CQRS
{
    public interface IDbMGMStoreCRUD<T>
    {
        IEnumerable<T> Select();

        T SelectById(int id);

        bool Insert(T model);

        bool Update(T model, int id = -1);

        bool Delete(T model, int id = -1);
    }
}
