using System.Collections.Generic;

namespace MGM.CQRS
{
    public interface IdbMgmStoreTagCRUD<T>
    {
        IEnumerable<T> Select();

        IEnumerable<T> SelectById(int tagId = 1, int valueId = 1);

        void Insert(T model);

        bool Update(T model, int id = -1);

        bool Delete(T model, int id = -1);
    }
}