using MGM.CQRS.Models;
using System.Collections.Generic;
using System.Linq;
using MGM.CQRS.Interface;

namespace MGM.CQRS.Store
{
    internal class MemeTagStore : IMemeTag
    {
        public bool Delete(Memetag model, int tagId = -1, int modelId = -1)
        {
            using (var context = new MGMContext())
            {
                if (tagId != -1 && modelId != -1)
                {
                    var MemetagId =
                        context.Memetag.FirstOrDefault(x => x.MemeId == modelId && x.TagId == tagId);
                    if (MemetagId != null)
                    {
                        context.Memetag.Remove(MemetagId);
                        context.SaveChanges();
                        return context.Memetag.FirstOrDefault(x => x.TagId == tagId && x.MemeId == modelId) == null;
                    }
                    return false;
                }
                var MemetagModel =
                    context.Memetag.FirstOrDefault(x => x.MemeId == model.MemeId && x.TagId == model.TagId);
                if (MemetagModel != null) 
                {
                    context.Memetag.Remove(MemetagModel);
                    context.SaveChanges();
                    return context.Memetag.FirstOrDefault(x => x.TagId == model.TagId && x.MemeId == model.MemeId) == null;
                }
                return false;
            }
        }

        public void Insert(Memetag model)
        {
            using (var context = new MGMContext())
            {
                context.Add(model);
                context.SaveChanges();
            }
        }

        public IEnumerable<Memetag> Select()
        {
            using (var context = new MGMContext())
                return context.Memetag.ToList();
        }

        public IEnumerable<Memetag> SelectById(int tagId, int valueId)
        {
            using (var context = new MGMContext())
            {
                if (tagId == -1 && valueId == -1)
                    return null;
                if (tagId == -1 && valueId != -1)
                    return context.Memetag.Where(x => x.MemeId == valueId);
                if (tagId != -1 && valueId == -1)
                    return context.Memetag.Where(x => x.TagId == tagId);

                return context.Memetag.Where(x => x.TagId == tagId && x.MemeId == valueId).ToList();
            }
        }

        public bool Update(Memetag model, int id = -1)
        {
            using (var context = new MGMContext())
            {
                var Memetag = context.Memetag.FirstOrDefault(x => x.TagId == model.TagId && x.MemeId == model.MemeId);
                if (Memetag == null)
                    return false;
                Memetag.TagId = model.TagId;
                Memetag.MemeId = model.MemeId;

                context.SaveChanges();

                return true;
            }
        }
    }
}
