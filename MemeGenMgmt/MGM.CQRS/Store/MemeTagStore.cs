using MGM.CQRS.Models;
using System.Collections.Generic;
using System.Linq;

namespace MGM.CQRS.Store
{
    internal class MemeTagStore
        : IDbMgmStoreTagCrud<MemesTag>
    {
        public bool Delete(MemesTag model, int id = -1)
        {
            using (var context = new MGMContext())
            {
                var memeTag =
                    context.MemesTag.FirstOrDefault(x => x.MemesId == model.MemesId && x.TagId == model.TagId);
                if (memeTag == null) return false;
                {
                    context.MemesTag.Remove(memeTag);
                    context.SaveChanges();
                    return context.MemesSet.FirstOrDefault(x => x.Id == id) == null;
                }
            }
        }

        public void Insert(MemesTag model)
        {
            using (var context = new MGMContext())
            {
                context.Add(model);
                context.SaveChangesAsync();
            }
        }

        public IEnumerable<MemesTag> Select()
        {
            using (var context = new MGMContext())
                return context.MemesTag;
        }

        public IEnumerable<MemesTag> SelectById(int tagId, int valueId)
        {
            using (var context = new MGMContext())
            {
                if (tagId == -1 && valueId == -1)
                    return null;
                if (tagId == -1 && valueId != -1)
                    return context.MemesTag.Where(x => x.MemesId == valueId);
                if (tagId != -1 && valueId == -1)
                    return context.MemesTag.Where(x => x.TagId == tagId);

                return context.MemesTag.Where(x => x.TagId == tagId && x.MemesId == valueId);
            }
        }

        public bool Update(MemesTag model, int id = -1)
        {
            using (var context = new MGMContext())
            {
                var memeTag = context.MemesTag.FirstOrDefault(x => x.TagId == model.TagId && x.MemesId == model.MemesId);
                if (memeTag == null)
                    return false;
                memeTag.TagId = model.TagId;
                memeTag.MemesId = model.MemesId;

                context.SaveChanges();

                return true;
            }
        }
    }
}
