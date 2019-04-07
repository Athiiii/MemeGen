using System.Collections.Generic;

namespace MGM.CQRS
{
    public interface IDbMgmStoreTagCrud<T>
    {
        IEnumerable<T> Select();

        IEnumerable<T> SelectById(int tagId = 1, int valueId = 1);

        void Insert(T model);

        bool Delete(T model, int tagId = -1, int modelId = -1);
    }
}