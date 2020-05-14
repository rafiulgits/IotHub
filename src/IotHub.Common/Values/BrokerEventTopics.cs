namespace IotHub.Common.Values
{
    public class BrokerEventTopics
    {
        private static string Base { get; } = "$SYS/broker";
        private static string ClientBase { get; } = $"{Base}/clients";

        public string ConnectedClients { get; } = $"{ClientBase}/connected";
        public string DisconnectedClients { get; } = $"{ClientBase}/disconnected";
        public string NewClientConnected { get; } = $"{ClientBase}/connected/new";
        public string NewClientDisconnected { get; } = $"{ClientBase}/disconnected/new";
        public string ConnectedClientsCount { get; } = $"{ClientBase}/connected/count";
        public string DisconnectedClientsCount { get; } = $"{ClientBase}/disconnected/count";
        public string SubscriptionsCount { get; } = $"{Base}/subscriptions/count";
        public string ClientIP(string clientId)
        {
            return $"{ClientBase}/{clientId}/ip";
        }

        public string ClientConnectedTime(string clientId)
        {
            return $"{ClientBase}/{clientId}/connectedtime";
        }
    }
}
