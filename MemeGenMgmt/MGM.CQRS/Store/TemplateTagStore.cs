using MGM.CQRS.Models;
using System.Collections.Generic;
using System.Linq;

namespace MGM.CQRS.Store
{
    public class TemplateTagStore
        : IDbMgmStoreTagCrud<TemplateTag>
    {
        public bool Delete(TemplateTag model, int id = -1)
        {
            using (var context = new MGMContext())
            {
                var templateTag =
                    context.TemplateTag.FirstOrDefault(x => x.TemplateId == model.TemplateId && x.TagId == model.TagId);
                if (templateTag == null) return false;
                {
                    context.TemplateTag.Remove(templateTag);
                    context.SaveChanges();
                    return context.TemplateTag.FirstOrDefault(x => x.TemplateId == model.TemplateId && x.TagId == model.TagId) == null;
                }
            }
        }

        public void Insert(TemplateTag model)
        {
            using (var context = new MGMContext())
            {
                context.TemplateTag.Add(model);
                context.SaveChanges();
            }
        }

        public IEnumerable<TemplateTag> Select()
        {
            using (var context = new MGMContext())
                return context.TemplateTag;
        }

        public IEnumerable<TemplateTag> SelectById(int tagId, int valueId)
        {
            using (var context = new MGMContext())
                return context.TemplateTag.Where(x => x.TagId == tagId && x.TemplateId == valueId);
        }

        public bool Update(TemplateTag model, int id = -1)
        {
            using (var context = new MGMContext())
            {
                var memeTag = context.TemplateTag.FirstOrDefault(x => x.TagId == model.TagId && x.TemplateId == model.TemplateId);
                if (memeTag == null)
                    return false;
                memeTag.TagId = model.TagId;
                memeTag.TemplateId = model.TemplateId;

                context.SaveChanges();

                return true;
            }
        }
    }
}
