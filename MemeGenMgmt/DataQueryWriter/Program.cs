using System;
using DataQueryWriter.extension;
using DataQueryWriter.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DataQueryWriter
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var path = @"C:\Users\Athavan\source\repos\MemeGen\MemeGenMgmt\MemeGen\wwwroot\template";
            var pathTo = @"C:\Users\Athavan\source\repos\MemeGen\MemeGenMgmt\MemeGen\wwwroot\";
            var service = new ServiceCollection().AddDataQueryDependencies();
            var templateService = service.BuildServiceProvider().GetService<ITemplate>();
            //templateService.CreateDataQuery(path);
            templateService.GenerateLazyImages(path, pathTo);

        }
    }
}
