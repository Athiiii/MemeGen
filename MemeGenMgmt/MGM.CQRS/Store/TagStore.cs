using System;
using System.Collections.Generic;
using System.Linq;
using MGM.API.Models;

namespace MGM.CQRS.Store
{
    internal class TagStore
        : IDbMgmStoreCrud<TagSet>
    {
        public bool Delete(TagSet model, int id = -1)
        {
            using (var context = new MGMContext())
            {
                if (id != -1)
                {
                    var tag = context.TagSet.FirstOrDefault(x => x.Id == id);
                    if (tag == null) return false;
                    {
                        context.TagSet.Remove(tag);
                        context.SaveChanges();
                        return context.MemesSet.FirstOrDefault(x => x.Id == id) == null;
                    }
                }

                context.Attach(model);
                context.TagSet.Remove(model);
                context.SaveChanges();
                return context.TagSet.FirstOrDefault(x => x.Id == model.Id) == null;
            }
        }

        public void Insert(TagSet model)
        {
            using (var context = new MGMContext())
            {
                context.TagSet.Add(model);
                context.SaveChangesAsync();
            }
        }

        public IEnumerable<TagSet> Select()
        {
            using (var context = new MGMContext())
                return context.TagSet;
        }

        public TagSet SelectById(int id)
        {
            using (var context = new MGMContext())
                return context.TagSet.FirstOrDefault(x => x.Id == id);
        }

        public bool Update(TagSet model, int id = -1)
        {
            using (var context = new MGMContext())
            {
                var tag = id != -1
                    ? context.TagSet.FirstOrDefault(x => x.Id == id)
                    : context.TagSet.FirstOrDefault(x => x.Id == model.Id);
                if (tag == null)
                    return false;

                tag.Description = model.Description;

                context.SaveChangesAsync();
                return true;
            }
        }
    }
}
