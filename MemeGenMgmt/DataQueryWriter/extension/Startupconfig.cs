using System;
using System.Collections.Generic;
using System.Text;
using DataQueryWriter.Helper;
using DataQueryWriter.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DataQueryWriter.extension
{
    public static class Startupconfig
    {
        public static IServiceCollection AddDataQueryDependencies(this IServiceCollection service)
        {
            service.AddScoped<ITemplate, Template>();

            return service;
        }
    }
}
