using MGM.CQRS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using MGM.CQRS.Interface;

namespace MGM.CQRS.Store
{
    public class MemeStore : IMeme
    {
        public bool Delete(Meme model, int id = -1)
        {
            using (var context = new MGMContext())
            {
                if (id != -1)
                {
                    var meme = context.Meme.FirstOrDefault(x => x.Id == id);
                    if (meme == null) return false;
                    {
                        context.Meme.Remove(meme);
                        context.SaveChanges();
                        return context.Meme.FirstOrDefault(x => x.Id == id) == null;
                    }
                }
                context.Attach(model);
                context.Meme.Remove(model);
                context.SaveChanges();
                return context.Meme.FirstOrDefault(x => x.Id == model.Id) == null;
            }
        }

        public void Insert(Meme model)
        {
            using (var context = new MGMContext())
            {
                context.Meme.Add(model);
                context.SaveChanges();
            }
        }

        public IEnumerable<Meme> Select()
        {
            using (var context = new MGMContext())
                return context.Meme.ToList();
        }

        public IEnumerable<Meme> SelectByUser(int userId)
        {
            using (var context = new MGMContext())
            {
                var list = context.Meme.Where(x => x.UserId == userId).ToList();
                if (list.Count > 1)
                    return list;
            }
            return new List<Meme>();
        }

        public Meme SelectById(int id)
        {
            using (var context = new MGMContext())
                return context.Meme.FirstOrDefault(x => x.Id == id);
        }

        public bool Update(Meme model, int id = -1)
        {
            using (var context = new MGMContext())
            {
                var meme = id != -1 ? context.Meme.FirstOrDefault(x => x.Id == id) : context.Meme.FirstOrDefault(x => x.Id == model.Id);
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
                meme.UserId = model.UserId;
                meme.Watermark = model.Watermark;

                context.SaveChanges();

                return true;
            }
        }
    }
}
