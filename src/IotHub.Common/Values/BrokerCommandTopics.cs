namespace IotHub.Common.Values
{
    public class BrokerCommandTopics
    {
        private static string Base { get; } = "$SYS/request/broker";
        private static string ClientBase { get; } = $"{Base}/clients";

        public string GetConnectedClients { get; } = $"{ClientBase}/connected";
        public string GetDisconnectedClients { get; } = $"{ClientBase}/disconnected";
        public string GetConnectedClientsCount { get; } = $"{ClientBase}/connected/count";
        public string GetDisconnectedClientsCount { get; } = $"{ClientBase}/disconnected/count";
        public string GetSubscriptionCount { get; } = $"{Base}/subscriptions/count";
        public string GetClientIP { get; } = $"{ClientBase}/ip";
        public string GetClientConnectedTime { get; } = $"{ClientBase}/connectedtime";
        public string PatchDisconnectClient { get; } = $"{ClientBase}/disconnect/command";
    }
}
