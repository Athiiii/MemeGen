using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MGM.CQRS;
using MGM.CQRS.Models;
using MGM.CQRS.Store;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MGM.API.Services
{
    public class DatabaseServices
    {
        public static IServiceCollection InitializeDatabase(IServiceCollection service)
        {
            service.AddScoped<IDbMgmStoreCrud<Meme>, MemeStore>();
            service.AddScoped<IDbMgmStoreCrud<Tag>, TagStore>();
            service.AddScoped<IDbMgmStoreCrud<Template>, TemplateStore>();
            service.AddScoped<IDbMgmStoreCrud<User>, UserStore>();
            service.AddScoped<IDbMgmStoreTagCrud<Templatetag>, TemplateTagStore>();
            service.AddScoped<IDbMgmStoreTagCrud<Memetag>, MemeTagStore>();

            /*
            service.AddDbContext<MGMContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("Connection")));
            */
            return service;
        }
    }
}
