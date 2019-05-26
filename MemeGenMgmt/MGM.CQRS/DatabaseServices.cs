using MGM.CQRS.Interface;
using MGM.CQRS.Models;
using MGM.CQRS.Store;
using Microsoft.Extensions.DependencyInjection;

namespace MGM.CQRS
{
    public static class DatabaseServices
    {
        public static IServiceCollection InitializeDatabase(this IServiceCollection service)
        {
            service.AddScoped<IMeme, MemeStore>();
            service.AddScoped<ITag, TagStore>();
            service.AddScoped<ITemplate, TemplateStore>();
            service.AddScoped<IUser, UserStore>();
            service.AddScoped<ITemplateTag, TemplateTagStore>();
            service.AddScoped<IMemeTag, MemeTagStore>();

            /*
            service.AddDbContext<MGMContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("Connection")));
            */
            return service;
        }
    }
}
