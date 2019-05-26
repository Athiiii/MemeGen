using MGM.CQRS.Models;
using System.Collections.Generic;
using System.Linq;
using MGM.CQRS.Interface;

namespace MGM.CQRS.Store
{
    internal class TagStore : ITag
    {
        public bool Delete(Tag model, int id = -1)
        {
            using (var context = new MGMContext())
            {
                if (id != -1)
                {
                    var tag = context.Tag.FirstOrDefault(x => x.Id == id);
                    if (tag == null) return false;
                    {
                        context.Tag.Remove(tag);
                        context.SaveChanges();
                        return context.Tag.FirstOrDefault(x => x.Id == id) == null;
                    }
                }

                context.Attach(model);
                context.Tag.Remove(model);
                context.SaveChanges();
                return context.Tag.FirstOrDefault(x => x.Id == model.Id) == null;
            }
        }

        public void Insert(Tag model)
        {
            using (var context = new MGMContext())
            {
                context.Tag.Add(model);
                context.SaveChanges();
            }
        }

        public IEnumerable<Tag> Select()
        {
            using (var context = new MGMContext())
                return context.Tag.ToList();
        }

        public Tag SelectById(int id)
        {
            using (var context = new MGMContext())
                return context.Tag.FirstOrDefault(x => x.Id == id);
        }

        public bool Update(Tag model, int id = -1)
        {
            using (var context = new MGMContext())
            {
                var tag = id != -1
                    ? context.Tag.FirstOrDefault(x => x.Id == id)
                    : context.Tag.FirstOrDefault(x => x.Id == model.Id);
                if (tag == null)
                    return false;

                tag.Description = model.Description;

                context.SaveChanges();
                return true;
            }
        }
    }
}
