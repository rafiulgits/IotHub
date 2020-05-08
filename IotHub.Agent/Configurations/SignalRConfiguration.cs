using IotHub.Agent.Hubs;
using Microsoft.AspNetCore.Builder;

namespace IotHub.Agent.Configurations
{
    public static class SignalRConfiguration
    {
        public static void UseConfiguredSignalR(this IApplicationBuilder app)
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<BrokerHub>("/agenthub");
            });
        }
    }
}
