﻿using MGM.CQRS.Models;
using System.Collections.Generic;
using System.Linq;
using MGM.CQRS.Interface;

namespace MGM.CQRS.Store
{
    internal class TemplateStore : ITemplate
    {
        public bool Delete(Template model, int id = -1)
        {
            using (var context = new MGMContext())
            {
                if (id != -1)
                {
                    var meme = context.Template.FirstOrDefault(x => x.Id == id);
                    if (meme == null) return false;
                    {
                        context.Template.Remove(meme);
                        context.SaveChanges();
                        return context.Template.FirstOrDefault(x => x.Id == id) == null;
                    }
                }
                context.Attach(model);
                context.Template.Remove(model);
                context.SaveChanges();
                return context.Template.FirstOrDefault(x => x.Id == model.Id) == null;
            }
        }

        public void Insert(Template model)
        {
            using (var context = new MGMContext())
            {
                context.Template.Add(model);
                context.SaveChanges();
            }
        }

        public IEnumerable<Template> Select()
        {
            using (var context = new MGMContext())
                return context.Template.ToList();
        }

        public Template SelectById(int id)
        {
            using (var context = new MGMContext())
                return context.Template.FirstOrDefault(x => x.Id == id);
        }

        public bool Update(Template model, int id = -1)
        {
            using (var context = new MGMContext())
            {
                var template = id != -1 ? context.Template.FirstOrDefault(x => x.Id == id) : context.Template.FirstOrDefault(x => x.Id == model.Id);
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
