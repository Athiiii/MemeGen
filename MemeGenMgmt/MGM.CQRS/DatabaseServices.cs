using MGM.CQRS.Models;
using MGM.CQRS.Store;
using Microsoft.Extensions.DependencyInjection;

namespace MGM.CQRS
{
    public static class DatabaseServices
    {
        public static IServiceCollection InitializeDatabase(this IServiceCollection service)
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
