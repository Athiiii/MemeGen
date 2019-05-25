using System.Collections.Generic;
using MGM.CQRS.Models;

namespace MGM.CQRS.Interface
{
    public interface ITemplate
    {
        bool Delete(Template model, int id = -1);
        void Insert(Template model);
        IEnumerable<Template> Select();
        Template SelectById(int id);
        bool Update(Template model, int id = -1);
    }
}
