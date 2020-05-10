namespace IotHub.Common.Values
{
    public class BrokerEventTopics
    {
        public string ClientConnected { get; } = "$SYS/users/connected";
        public string ClientDisconnected { get; } = "$SYS/users/disconnected";
    }
}
