using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace IotHub.Agent
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    var env = hostingContext.HostingEnvironment;
                    var sharedFolder = Path.GetFullPath(Path.Combine(env.ContentRootPath, @"..\..\"));
                    config.AddJsonFile(Path.Combine(sharedFolder, "sharedSettings.json"), optional: false)
                          .AddJsonFile("sharedSettings.json", optional: true) //for production
                          .AddJsonFile("appsettings.json", optional: true)
                          .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

                    config.AddEnvironmentVariables();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
