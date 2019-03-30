using MGM.CQRS.Models;
using System.Collections.Generic;
using System.Linq;

namespace MGM.CQRS.Store
{
    public class TemplateStore
        : IDbMgmStoreCrud<TemplateSet>
    {
        public bool Delete(TemplateSet model, int id = -1)
        {
            using (var context = new MGMContext())
            {
                if (id != -1)
                {
                    var meme = context.TemplateSet.FirstOrDefault(x => x.Id == id);
                    if (meme == null) return false;
                    {
                        context.TemplateSet.Remove(meme);
                        context.SaveChanges();
                        return context.TemplateSet.FirstOrDefault(x => x.Id == id) == null;
                    }
                }
                context.Attach(model);
                context.TemplateSet.Remove(model);
                context.SaveChanges();
                return context.TemplateSet.FirstOrDefault(x => x.Id == model.Id) == null;
            }
        }

        public void Insert(TemplateSet model)
        {
            using (var context = new MGMContext())
            {
                context.TemplateSet.Add(model);
                context.SaveChanges();
            }
        }

        public IEnumerable<TemplateSet> Select()
        {
            using (var context = new MGMContext())
                return context.TemplateSet;
        }

        public TemplateSet SelectById(int id)
        {
            using (var context = new MGMContext())
                return context.TemplateSet.FirstOrDefault(x => x.Id == id);
        }

        public bool Update(TemplateSet model, int id = -1)
        {
            using (var context = new MGMContext())
            {
                var template = id != -1 ? context.TemplateSet.FirstOrDefault(x => x.Id == id) : context.TemplateSet.FirstOrDefault(x => x.Id == model.Id);
                if (template == null)
                    return false;

                template.ImagePath = model.ImagePath;
                template.Name = model.Name;

                context.SaveChanges();

                return true;
            }
        }
    }
}
