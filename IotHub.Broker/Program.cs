using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using MQTTnet.AspNetCore;

namespace IotHub.Broker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseKestrel(option =>
                    {
                        option.ListenAnyIP(1883, listenter => listenter.UseMqtt());
                        option.ListenAnyIP(4000); // default HTTP Port
                    });
                    webBuilder.UseStartup<Startup>();
                });
    }
}
