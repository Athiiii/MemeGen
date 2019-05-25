using MGM.CQRS.Models;
using System.Collections.Generic;
using System.Linq;
using MGM.CQRS.Interface;

namespace MGM.CQRS.Store
{
    internal class TemplateTagStore : ITemplateTag
    {
        public bool Delete(Templatetag model, int tagId, int modelId)
        {
            using (var context = new MGMContext())
            {
                if (tagId != -1 && modelId != -1)
                {
                    var templatetagTagId =
                        context.Templatetag.FirstOrDefault(x => x.TemplateId == modelId && x.TagId == tagId);
                    if (templatetagTagId != null)
                    {
                        context.Templatetag.Remove(templatetagTagId);
                        context.SaveChanges();
                        return context.Templatetag.FirstOrDefault(x => x.TagId == tagId && x.TemplateId == modelId) == null;
                    }
                    return false;
                }
                var TemplatetagModel =
                    context.Templatetag.FirstOrDefault(x => x.TemplateId == model.TemplateId && x.TagId == model.TagId);
                if (TemplatetagModel != null)
                {
                    context.Templatetag.Remove(TemplatetagModel);
                    context.SaveChanges();
                    return context.Templatetag.FirstOrDefault(x => x.TagId == model.TagId && x.TemplateId == model.TemplateId) == null;
                }
                return false;
            }
        }

        public void Insert(Templatetag model)
        {
            using (var context = new MGMContext())
            {
                context.Templatetag.Add(model);
                context.SaveChanges();
            }
        }

        public IEnumerable<Templatetag> Select()
        {
            using (var context = new MGMContext())
                return context.Templatetag.ToList();
        }

        public IEnumerable<Templatetag> SelectById(int tagId, int valueId)
        {
            using (var context = new MGMContext())
                return context.Templatetag.Where(x => x.TagId == tagId && x.TemplateId == valueId).ToList();
        }

        public bool Update(Templatetag model, int id = -1)
        {
            using (var context = new MGMContext())
            {
                var memeTag = context.Templatetag.FirstOrDefault(x => x.TagId == model.TagId && x.TemplateId == model.TemplateId);
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
