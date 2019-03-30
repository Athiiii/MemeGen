using MGM.CQRS.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MGM.CQRS.Store
{
    public class MemeStore : IDbMgmStoreCrud<MemesSet>
    {
        public bool Delete(MemesSet model, int id = -1)
        {
            using (var context = new MGMContext())
            {
                if (id != -1)
                {
                    var meme = context.MemesSet.FirstOrDefault(x => x.Id == id);
                    if (meme == null) return false;
                    {
                        context.MemesSet.Remove(meme);
                        context.SaveChanges();
                        return context.MemesSet.FirstOrDefault(x => x.Id == id) == null;
                    }
                }
                context.Attach(model);
                context.MemesSet.Remove(model);
                context.SaveChanges();
                return context.MemesSet.FirstOrDefault(x => x.Id == model.Id) == null;
            }
        }

        public void Insert(MemesSet model)
        {
            using (var context = new MGMContext())
            {
                context.MemesSet.Add(model);
                context.SaveChanges();
            }
        }

        public IEnumerable<MemesSet> Select()
        {
            using (var context = new MGMContext())
                return context.MemesSet;
        }

        public MemesSet SelectById(int id)
        {
            using (var context = new MGMContext())
                return context.MemesSet.FirstOrDefault(x => x.Id == id);
        }

        public bool Update(MemesSet model, int id = -1)
        {
            using (var context = new MGMContext())
            {
                var meme = id != -1 ? context.MemesSet.FirstOrDefault(x => x.Id == id) : context.MemesSet.FirstOrDefault(x => x.Id == model.Id);
                if (meme == null)
                    return false;
                meme.Bottom = model.Bottom;
                meme.Created = model.Created;
                meme.FontSize = model.FontSize;
                meme.ImagePath = model.ImagePath;
                meme.Name = model.Name;
                meme.TemplateId = model.TemplateId;
                meme.Top = model.Top;
                meme.Updated = DateTime.Now;
                meme.UsersId = model.UsersId;
                meme.Watermark = model.Watermark;

                context.SaveChanges();

                return true;
            }
        }
    }
}
